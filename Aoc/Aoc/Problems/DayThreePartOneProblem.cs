using Aoc.Interfaces;

namespace Aoc.Problems
{
    public class DayThreePartOneProblem : ProblemBase, IProblem
    {
        public DayThreePartOneProblem()
        {
            inputFileName = ParseInputFileName(nameof(DayThreePartOneProblem));
        }
        
        public void Solve()
        {
            Logger.Start(nameof(DayThreePartOneProblem));
            Logger.Complete(nameof(DayThreePartOneProblem));
        }
    }
}
