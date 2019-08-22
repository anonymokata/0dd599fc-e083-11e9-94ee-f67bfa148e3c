using EHale.Wordsearch.Entities;
using System;

namespace EHale.Wordsearch.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Puzzle puzzle = new Puzzle(@"C:\temp\puzzle.txt");
            string[] results = puzzle.Solve();

            foreach(string result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}
