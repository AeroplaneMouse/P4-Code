using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Values
{
    class IntValueNode : ValueNode
    {
        public int Value { get; set; }

        public IntValueNode(int value)
        {
            Value = value;
        }
    }
}
