using CellularCompiler.Nodes.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
{
    class StateNode : BaseNode
    {
        public List<string> Labels { get; set; }
        public List<MemberNode> Members { get; set; }

        public StateNode()
            : this(null, null) { }

        public StateNode(List<string> labels, List<MemberNode> members)
        {
            Labels = labels;
            Members = members;
        }
    }
}
