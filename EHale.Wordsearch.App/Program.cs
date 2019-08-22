using EHale.Wordsearch.Entities;
using System;

namespace EHale.Wordsearch.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the full path to your text file containing a puzzle:");
            string path = Console.ReadLine();
            Puzzle puzzle = new Puzzle(path);
            string[] results = puzzle.Solve();

            foreach(string result in results)
            {
                Console.WriteLine(result);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
