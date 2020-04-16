﻿using CellularCompiler.Models;
using CellularCompiler.Nodes.Base;

namespace CellularCompiler.Evaluators
{
    class EvaluateGridVisitor
    {
        public Grid Visit(GridNode node)
        {
            int x = new EvaluateMemberVisitor().Visit(node.Members[0]);
            int y = new EvaluateMemberVisitor().Visit(node.Members[1]);
            return new Grid(x, y);
        }
    }
}
