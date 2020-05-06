using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Values
{
    class StringValueNode : ValueNode
    {
        public string Value { get; set; }

        public StringValueNode(string value)
        {
            Value = value;
        }
    }
}
