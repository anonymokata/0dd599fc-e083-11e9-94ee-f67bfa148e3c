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

            for(int posY = 0; posY < _board.GetLength(0); posY++)
            {
                for(int posX = 0; posX < _board.GetLength(0); posX++)
                {
                    if(_board[posX, posY] == wordArray[0])
                    {
                        possiblePoints.Add(new List<SearchPoint> { new SearchPoint(posX, posY, wordArray[0]) });
                    }
                }
            }

            for(int charPosition = 1; charPosition < wordArray.Length; charPosition++)
            {
                foreach(List<SearchPoint> possible in Enumerable.Reverse(possiblePoints))
                {
                    bool stillPossible = false;

                    // Horizontal
                    if(possible[charPosition - 1].X + 1 < _board.GetLength(0) &&
                        _board[possible[charPosition - 1].X + 1, possible[charPosition - 1].Y] == wordArray[charPosition])
                    {
                        possible.Add(new SearchPoint(possible[charPosition - 1].X + 1, possible[charPosition - 1].Y, wordArray[charPosition]));
                        stillPossible = true;
                    }

                    // Vertical
                    if (possible[charPosition - 1].Y + 1 < _board.GetLength(0) &&
                        _board[possible[charPosition - 1].X, possible[charPosition - 1].Y + 1] == wordArray[charPosition])
                    {
                        possible.Add(new SearchPoint(possible[charPosition - 1].X, possible[charPosition - 1].Y + 1, wordArray[charPosition]));
                        stillPossible = true;
                    }

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
    }
}
