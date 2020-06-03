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

            WireGrid wireGrid = new WireGrid();
            foreach (string input in GetInput())
            {
                wireGrid.TraceWire(input);
            }

            Logger.Complete(nameof(DayThreePartOneProblem));
        }
    }
}
