using System;
using System.Text;
using System.Collections.Generic;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Nodes.Values 
{
    class GridValueNode : ValueNode
    {
        public ExpressionNode FirstD { get; set; }
        public ExpressionNode SecondD { get; set; }

        public GridValueNode()
            : this(null, null) { }

        public GridValueNode(ExpressionNode first, ExpressionNode second)
        {
            FirstD = first;
            SecondD = second;
        }
    }
}
