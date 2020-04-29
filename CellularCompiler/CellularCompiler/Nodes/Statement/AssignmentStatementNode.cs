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
        public string Value { get; set; }

        public AssignmentStatementNode()
            : this(null, null, null, null) { }

        public AssignmentStatementNode(GridPointNode gridPointNode, MemberIDNode memberIDNode, string value)
            : this(gridPointNode, memberIDNode, null, value) { }

        public AssignmentStatementNode(GridPointNode gridPointNode, MemberIDNode memberIDNode, ExpressionNode expr)
            : this(gridPointNode, memberIDNode, expr, null) { }

        public AssignmentStatementNode(GridPointNode gridPointNode, MemberIDNode memberIDNode, ExpressionNode expressionNode, string value)
        {
            GridPoint = gridPointNode;
            MemberIDNode = memberIDNode;
            ExpressionNode = expressionNode;
            Value = value;
        }
    }
        
}
