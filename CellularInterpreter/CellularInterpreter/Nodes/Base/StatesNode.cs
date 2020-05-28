using System;
using System.Text;
using System.Collections.Generic;
using CI.Nodes.Values;
using CI.Nodes.Members;

namespace CI.Nodes.Base
{
    class StatesNode : BaseNode
    {
        public List<string> Labels { get; set; }
        public List<MemberNode> Members { get; set; }

        public StatesNode()
            : this(null, null) { }

        public StatesNode(List<string> labels, List<MemberNode> members)
        {
            Labels = labels;
            Members = members;
        }
    }
}
