using CellularCompiler.Nodes.Math;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text;

namespace CellularCompiler.Nodes
{
    class GridPointNode
    {
        public List<ExpressionNode> ExpressionNodes { get; set; }

        public GridPointNode()
            : this(null) { }

        public GridPointNode(List<ExpressionNode> expressionNodes)
        {
            ExpressionNodes = expressionNodes;
        }
    }
}
