using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Members
{
    class IdentifierValueNode : MemberValueNode
    {
        public string Label { get; set; }

        public IdentifierValueNode(string label)
        {
            Label = label;
        }
    }
}
