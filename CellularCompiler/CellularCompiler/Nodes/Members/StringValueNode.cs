using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Members
{
    class StringValueNode : MemberValueNode
    {
        public string Value { get; set; }

        public StringValueNode(string value)
        {
            Value = value;
        }
    }
}
