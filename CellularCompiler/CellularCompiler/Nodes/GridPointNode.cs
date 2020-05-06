using System;
using System.Text;
using System.Collections.Generic;
using CellularCompiler.Nodes.Math;

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
