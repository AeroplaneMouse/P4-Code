using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Values
{
    class MemberIDNode
    {
        public string Label { get; set; }

        public MemberIDNode(string label)
        {
            Label = label;
        }
    }
}
