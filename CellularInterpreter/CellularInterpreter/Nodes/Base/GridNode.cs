using System.Collections.Generic;
using CI.Nodes.Members;

namespace CI.Nodes.Base
{
    class GridNode : BaseNode
    {
        public List<MemberNode> Members { get; set; }

        public GridNode(List<MemberNode> members)
        {
            Members = members;
        }
    }
}
