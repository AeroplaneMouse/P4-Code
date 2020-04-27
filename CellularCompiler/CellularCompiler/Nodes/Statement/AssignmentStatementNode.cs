using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Members;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CellularCompiler.Nodes.Statement
{
    class AssignmentStatementNode : StatementNode
    {
        public GridPointNode GridPoint { get; set; }
        public MemberIDNode MemberIDNode { get; set; }
        public ExpressionNode ExpressionNode { get; set; }

        public AssignmentStatementNode()
            : this(null, null, null) { }

        public AssignmentStatementNode(GridPointNode gridPointNode, MemberIDNode memberIDNode, ExpressionNode expressionNode)
        {
            GridPoint = gridPointNode;
            MemberIDNode = memberIDNode;
            ExpressionNode = expressionNode;
        }
    }
}
