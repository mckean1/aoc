using Aoc.Interfaces;
using System;

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
            IWireGrid wireGrid = new WireGrid();

            foreach (string input in GetInput())
            {
                wireGrid.TraceWire(input);
            }

            int closestDistance = wireGrid.GetDistanceToClosestIntersection();
            Logger.Log($"{Environment.NewLine}The closest intersection is {closestDistance}.");

            Logger.Complete(nameof(DayThreePartOneProblem));
        }
    }
}
