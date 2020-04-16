using System.Collections.Generic;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Nodes.Base
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
