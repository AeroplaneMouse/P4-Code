using System;
using System.Collections.Generic;
using System.Text;

namespace CI.Models
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

        public override bool Equals(object obj)
        {
            if (obj is Pos p)
                return X == p.X && Y == p.Y;
            else
                return false;
        }
    }
}
