using Aoc.Enums;
using Aoc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc
{
    public class WireGrid : IWireGrid
    {
        private Dictionary<WireCellLookup, WireCell> wireCells;

        private int currentX;
        private int currentY;
        private int currentWireNumber;

        public WireGrid()
        {
            wireCells = new Dictionary<WireCellLookup, WireCell>();

            currentX = 0;
            currentY = 0;
            currentWireNumber = 0;
        }

        public void TraceWire(string input)
        {
            StartTrace();

            string[] wireInputs = input.Split(',');

            foreach (string wireInput in wireInputs)
            {
                Logger.Log($"Tracing wire input: {wireInput}.");
                int.TryParse(wireInput.Substring(1), out int length);

                switch (wireInput[0])
                {
                    case 'U':
                        SaveWireInput(WireDirection.Up, length);
                        break;
                    case 'D':
                        SaveWireInput(WireDirection.Down, length);
                        break;
                    case 'L':
                        SaveWireInput(WireDirection.Left, length);
                        break;
                    case 'R':
                        SaveWireInput(WireDirection.Right, length);
                        break;
                    default:
                        throw new NotSupportedException($"{nameof(wireInput)} value of {wireInput} is not supported.");
                }
            }
        }

        public int GetDistanceToClosestIntersection()
        {
            int closestDistance = int.MaxValue;

            foreach (WireCell wireCell in wireCells.Values.Where(x => x.IsIntersection))
            {
                int distance = Math.Abs(wireCell.X) + Math.Abs(wireCell.Y);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                }
            }

            return closestDistance;
        }

        private void SaveWireInput(WireDirection wireDirection, int length)
        {
            for (int i = 0; i < length; i++)
            {
                switch (wireDirection)
                {
                    case WireDirection.Up:
                        currentY++;
                        break;
                    case WireDirection.Down:
                        currentY--;
                        break;
                    case WireDirection.Left:
                        currentX--;
                        break;
                    case WireDirection.Right:
                        currentX++;
                        break;
                    default:
                        throw new NotSupportedException($"{nameof(WireDirection)} value of {wireDirection} is not supported.");
                }

                AddWireCell(currentX, currentY);
            }
        }

        private void AddWireCell(int x, int y)
        {
            WireCellLookup wireCellLookup = new WireCellLookup
            {
                X = x,
                Y = y
            };

            WireCell wireCell = new WireCell
            {
                X = x,
                Y = y,
                WireNumber = currentWireNumber
            };

            bool isCrossing = wireCells.TryAdd(wireCellLookup, wireCell);

            if (!isCrossing && !IsSameWire(wireCellLookup))
            {
                Logger.Log($"Intersection at X: {x} and Y: {y}.");
                wireCells[wireCellLookup].IsIntersection = true;
            }
        }

        private bool IsSameWire(WireCellLookup wireCellLookup)
        {
            return wireCells[wireCellLookup].WireNumber == currentWireNumber;
        }

        private void StartTrace()
        {
            currentX = 0;
            currentY = 0;
            currentWireNumber++;

            Logger.Log($"{Environment.NewLine}Starting trace for wire {currentWireNumber}.");
        }
    }
}
