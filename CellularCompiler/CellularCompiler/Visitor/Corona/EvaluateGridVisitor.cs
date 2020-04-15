using CellularCompiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularCompiler.Visitor.Corona
{
    class EvaluateGridVisitor
    {

        public Grid Visit(GridNode node)
        {
            int x = new EvaluateMemberVisitor().Visit(node.Members[0]);
            int y = new EvaluateMemberVisitor().Visit(node.Members[1]);
            return new Grid(x, y);
        }


        //public Grid Visit(ExpressionNode node)
        //{
        //    return Visit((dynamic)node);
        //}
    }

    class EvaluateMemberVisitor
    {
        
        public int Visit(ArrowValueNode node)
            => node.RightValue;


        public int Visit(MemberNode node)
        {
            return Visit((dynamic)node.Values.First());
        }
    }

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
