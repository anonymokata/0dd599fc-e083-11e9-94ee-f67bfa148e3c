using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EHale.Wordsearch.Entities
{
    public class SearchBoard
    {
        private readonly char[,] _board;

        public SearchBoard(string[] board)
        {
            _board = new char[board.Length, board.Length];

            for(int posY = 0; posY < board.Length; posY++)
            {
                string[] row = board[posY].Split(',');

                for(int posX = 0; posX < row.Length; posX++)
                {
                    _board[posX, posY] = char.Parse(row[posX]);
                }
            }
        }

        public string Find(string word)
        {
            char[] wordArray = word.ToCharArray();

            List<List<SearchPoint>> possiblePoints = new List<List<SearchPoint>>();

            // Find all possible start point
            for(int posY = 0; posY < _board.GetLength(0); posY++)
            {
                for(int posX = 0; posX < _board.GetLength(0); posX++)
                {
                    if(_board[posX, posY] == wordArray[0])
                    {
                        // Add entries for every possible direction around the start point
                        for(int aroundPositions = 0; aroundPositions < 8; aroundPositions++)
                        {
                            possiblePoints.Add(new List<SearchPoint> { new SearchPoint(posX, posY, wordArray[0]) {
                                Direction = (Direction)aroundPositions
                            }});
                        }
                    }
                }
            }

            for(int charPosition = 1; charPosition < wordArray.Length; charPosition++)
            {
                foreach(List<SearchPoint> possible in Enumerable.Reverse(possiblePoints))
                {
                    bool stillPossible = false;
                    
                    stillPossible = stillPossible || SearchInDirection(Direction.Horizontal, possible, wordArray, charPosition, 1, 0);
                    stillPossible = stillPossible || SearchInDirection(Direction.Vertical, possible, wordArray, charPosition, 0, 1);
                    stillPossible = stillPossible || SearchInDirection(Direction.DiagonalDescending, possible, wordArray, charPosition, 1, 1);
                    stillPossible = stillPossible || SearchInDirection(Direction.DiagonalAscending, possible, wordArray, charPosition, 1, -1);
                    stillPossible = stillPossible || SearchInDirection(Direction.HorizontalBackwards, possible, wordArray, charPosition, -1, 0);
                    stillPossible = stillPossible || SearchInDirection(Direction.VerticalBackwards, possible, wordArray, charPosition, 0, -1);
                    stillPossible = stillPossible || SearchInDirection(Direction.DiagonalDescendingBackwards, possible, wordArray, charPosition, -1, -1);
                    stillPossible = stillPossible || SearchInDirection(Direction.DiagonalAscendingBackwards, possible, wordArray, charPosition, -1, 1);

                    if (!stillPossible)
                    {
                        possiblePoints.Remove(possible);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"{word}: ");
            possiblePoints[0].ForEach(pt => sb.Append($"({pt.X},{pt.Y}){(possiblePoints[0].Count - 1 == possiblePoints[0].IndexOf(pt) ? "" : ",")}"));

            return sb.ToString();
        }

        private bool SearchInDirection(Direction searchDirection,
            List<SearchPoint> possible,
            char[] wordArray,
            int charPosition,
            int xAdjustment,
            int yAdjustment
            )
        {
            if (possible[charPosition - 1].Direction == searchDirection &&
                possible[charPosition - 1].X + xAdjustment >= 0 &&
                possible[charPosition - 1].X + xAdjustment < _board.GetLength(0) &&
                possible[charPosition - 1].Y + yAdjustment >= 0 &&
                possible[charPosition - 1].Y + yAdjustment < _board.GetLength(0) &&
                _board[possible[charPosition - 1].X + xAdjustment, possible[charPosition - 1].Y + yAdjustment] == wordArray[charPosition])
            {
                possible.Add(new SearchPoint(possible[charPosition - 1].X + xAdjustment, possible[charPosition - 1].Y + yAdjustment, wordArray[charPosition])
                {
                    Direction = searchDirection
                });
                return true;
            }

            return false;
        }
    }
}
