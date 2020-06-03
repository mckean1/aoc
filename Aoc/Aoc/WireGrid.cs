using Aoc.Enums;
using System;
using System.Collections.Generic;

namespace Aoc
{
    public class WireGrid
    {
        private Dictionary<WireCellLookup, WireCell> wireCellDictionary;

        public WireGrid()
        {
            wireCellDictionary = new Dictionary<WireCellLookup, WireCell>();
        }

        public void TraceWire(string input)
        {
            string[] wireInputs = input.Split(',');

            foreach (string wireInput in wireInputs)
            {
                Logger.Log($"Tracing wire input: {wireInput}.");
                int.TryParse(wireInput.Substring(1), out int length);

                if (wireInput[0] == 'U')
                {
                    SaveWireInput(WireDirection.Up, length);
                }

                else if (wireInput[0] == 'D')
                {
                    SaveWireInput(WireDirection.Down, length);
                }

                else if (wireInput[0] == 'L')
                {
                    SaveWireInput(WireDirection.Left, length);
                }

                else if (wireInput[0] == 'R')
                {
                    SaveWireInput(WireDirection.Right, length);
                }
            }
        }

        private void SaveWireInput(WireDirection wireDirection, int length)
        {
            int currentX = 0;
            int currentY = 0;

            for (int i = 0; i < length; i++)
            {
                switch (wireDirection)
                {
                    case WireDirection.Up:
                        AddWireCell(currentX, currentY + 1);
                        break;
                    case WireDirection.Down:
                        AddWireCell(currentX, currentY - 1);
                        break;
                    case WireDirection.Left:
                        AddWireCell(currentX - 1, currentY);
                        break;
                    case WireDirection.Right:
                        AddWireCell(currentX + 1, currentY);
                        break;
                    default:
                        throw new NotSupportedException($"{nameof(WireDirection)} value of {wireDirection} is not supported.");
                }
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
                Y = y
            };

            bool isAdded = wireCellDictionary.TryAdd(wireCellLookup, wireCell);

            if (!isAdded)
            {
                wireCellDictionary[wireCellLookup].X = x;
                wireCellDictionary[wireCellLookup].Y = y;
            }
        }
    }
}
