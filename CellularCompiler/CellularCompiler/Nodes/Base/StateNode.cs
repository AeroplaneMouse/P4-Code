using CellularCompiler.Nodes.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
{
    class StateNode : BaseNode
    {
        public string Label { get; set; }
        public List<MemberNode> Members { get; set; }

        public StateNode(string label, List<MemberNode> members)
        {
            Label = label;
            Members = members;
        }
    }
}
