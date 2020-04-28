using CellularCompiler.Nodes.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
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
