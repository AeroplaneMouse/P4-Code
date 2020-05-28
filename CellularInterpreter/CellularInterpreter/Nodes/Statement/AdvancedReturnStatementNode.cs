using System.Collections.Generic;
using CI.Nodes.Values;
using CI.Nodes.Members;

namespace CI.Nodes.Statement
{
    class AdvancedReturnStatementNode : ReturnStatementNode
    {
        public List<ReturnMemberNode> ReturnMembers { get; set; }

        public AdvancedReturnStatementNode(IdentifierValueNode id, List<ReturnMemberNode> returnMembers)
            : base(id)
        {
            ReturnMembers = returnMembers;
        }
    }
}
