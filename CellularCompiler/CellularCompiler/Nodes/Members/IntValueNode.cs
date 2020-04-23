using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Members
{
    class IntValueNode : MemberValueNode
    {
        public int Value { get; set; }

        public IntValueNode(int value)
        {
            Value = value;
        }
    }
}
