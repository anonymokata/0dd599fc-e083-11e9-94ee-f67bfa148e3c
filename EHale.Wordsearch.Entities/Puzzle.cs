using System.Collections.Generic;
using System.IO;

namespace EHale.Wordsearch.Entities
{
    public class Puzzle
    {
        private SearchBoard _board;
        private string[] _words;

        public Puzzle(string path)
        {
            LoadFromFile(path);
        }

        public string[] Solve()
        {
            List<string> results = new List<string>();

            foreach(string word in _words)
            {
                results.Add(_board.Find(word));
            }

            return results.ToArray();
        }

        private void LoadFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);

            _words = lines[0].Split(',');
            List<string> boardRows = new List<string>();

            for(int fileRow = 1; fileRow < lines.Length; fileRow++)
            {
                boardRows.Add(lines[fileRow]);
            }

            _board = new SearchBoard(boardRows.ToArray());
        }
    }
}
