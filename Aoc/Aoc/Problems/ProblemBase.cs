using System;
using System.IO;

namespace Aoc.Problems
{
    public abstract class ProblemBase
    {
        protected string inputFileName;

        protected string ParseInputFileName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return @$"InputFiles/{name.Replace("PartOne", string.Empty).Replace("PartTwo", string.Empty)}.txt";
        }

        protected string[] GetInput()
        {
            if (string.IsNullOrWhiteSpace(inputFileName))
            {
                throw new Exception($"{nameof(inputFileName)} is not set.");
            }

            return File.ReadAllLines(inputFileName);
        }
    }
}
