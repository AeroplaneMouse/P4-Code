using System;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Nodes.Statement
{
    class GridAssignmentStatementNode : AssignmentStatementNode
    {
        public GridValueNode GridPoint { get; set; }
        public IdentifierValueNode MemberID {get;set; }
        public IdentifierValueNode Identifier { get; set;}

        public GridAssignmentStatementNode(GridValueNode gridPoint, IdentifierValueNode memberID, IdentifierValueNode id)
        {
            GridPoint = gridPoint;
            MemberID = memberID;
            Identifier = id;
        }
    }
}
