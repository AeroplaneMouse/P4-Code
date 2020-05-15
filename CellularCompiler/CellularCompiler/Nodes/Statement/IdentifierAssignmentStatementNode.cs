using System;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Nodes.Statement
{
    class IdentifierAssignmentStatementNode : AssignmentStatementNode
    {
        public IdentifierValueNode Identifier { get; set; }
        public ExpressionNode Expression { get; set; }

        public IdentifierAssignmentStatementNode(IdentifierValueNode id, ExpressionNode expr)
        {
            Identifier = id;
            Expression = expr;
        }
    }
}
