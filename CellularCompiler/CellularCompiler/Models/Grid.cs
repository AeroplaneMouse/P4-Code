using System;

namespace CellularCompiler.Models
{
    public class Grid
    {
        public int XSize { get; }
        public int YSize { get; }

        public int[,] Values { get; }

        public Grid(int xSize, int ySize)
        {
            XSize = xSize;
            YSize = ySize;

            Values = new int[XSize, YSize];
        }

        public override string ToString()
        {
            string result = String.Empty;

            for(int r = 0; r < XSize; r++)
            {
                for(int c = 0; c < YSize; c++)
                    result += $" { Values[r, c] }";
                result += Environment.NewLine;
            }

            return result;
        }

    }
}
