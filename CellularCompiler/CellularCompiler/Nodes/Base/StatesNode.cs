using System;
using System.Text;
using System.Collections.Generic;
using CellularCompiler.Nodes.Values;
using CellularCompiler.Nodes.Members;

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
