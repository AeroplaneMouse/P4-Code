using System;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Nodes.Statement
{
    class GridAssignmentStatementNode : AssignmentStatementNode
    {
        public GridPointNode GridPoint { get; set; }
        public MemberIDNode MemberID {get;set; }
        public string IdentifierLabel { get; set;}

        public GridAssignmentStatementNode(GridPointNode gridPoint, MemberIDNode memberID, string identifierLabel)
        {
            GridPoint = gridPoint;
            MemberID = memberID;
            IdentifierLabel = identifierLabel;
        }
    }
}
