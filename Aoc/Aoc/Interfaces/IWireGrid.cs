namespace Aoc.Interfaces
{
    public interface IWireGrid
    {
        void TraceWire(string input);
        int GetDistanceToClosestIntersection();
    }
}
