using System.Collections.Generic;
using CellularCompiler.Nodes.Values;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Nodes.Statement
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
