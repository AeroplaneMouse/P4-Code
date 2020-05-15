using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Math
{
    class IdentifierNode : ExpressionNode
    {
        public string Label { get; set; }

        public IdentifierNode(string label)
        {
            Label = label;
        }
    }
}
