using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Values
{
    class IdentifierValueNode : ValueNode
    {
        public string Label { get; set; }

        public IdentifierValueNode(string label)
        {
            Label = label;
        }
    }
}
