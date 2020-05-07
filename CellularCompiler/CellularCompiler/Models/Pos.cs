using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    public class Pos
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pos(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Pos Copy()
        {
            return new Pos(X, Y);
        }
    }
}
