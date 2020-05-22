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
        public ValueNode Value { get; set; }

        public MemberAssignmentStatementNode(GridValueNode gridPoint, IdentifierValueNode memberID, ValueNode value)
        {
            GridPoint = gridPoint;
            MemberID = memberID;
            Value = value;
        }
    }
}
