using System;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Nodes.Statement
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
