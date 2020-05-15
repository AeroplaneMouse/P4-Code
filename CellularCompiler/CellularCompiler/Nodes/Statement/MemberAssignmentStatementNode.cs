using System;
using System.Text;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Nodes.Statement
{
    class MemberAssignmentStatementNode : StatementNode
    {
        public GridValueNode GridPoint { get; set; }
        public IdentifierValueNode MemberID { get; set; }
        public ExpressionNode Expr { get; set; }

        public MemberAssignmentStatementNode(GridValueNode gridPoint, IdentifierValueNode memberID, ExpressionNode expr)
        {
            GridPoint = gridPoint;
            MemberID = memberID;
            Expr = expr;
        }
    }
}
