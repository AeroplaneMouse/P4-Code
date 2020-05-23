using System;
using CI.Nodes.Math;
using CI.Nodes.Values;

namespace CI.Nodes.Statement
{
    class IdentifierAssignmentStatementNode : AssignmentStatementNode
    {
        public IdentifierValueNode Identifier { get; set; }
        public ValueNode Value { get; set; }

        public IdentifierAssignmentStatementNode(IdentifierValueNode id, ValueNode value)
        {
            Identifier = id;
            Value = value;
        }
    }
}
