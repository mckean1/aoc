using System;

namespace Aoc
{
    public static class Logger
    {
        public static void Start(string problemName)
        {
            Console.WriteLine($"Solving {problemName}.");
        }

        public static void Finish(string problemName)
        {
            Console.WriteLine($"Finished {problemName}.");
        }

        public static void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}
