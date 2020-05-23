using System;
using CI.Nodes.Values;

namespace CI.Nodes.Statement
{
    class GridAssignmentStatementNode : AssignmentStatementNode
    {
        public GridValueNode GridPoint { get; set; }
        public IdentifierValueNode Identifier { get; set;}

        public GridAssignmentStatementNode(GridValueNode gridPoint, IdentifierValueNode id)
        {
            GridPoint = gridPoint;
            Identifier = id;
        }
    }
}
