using System;
using System.Collections.Generic;
using System.Text;
using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Nodes.Statement
{
    class ReturnStatementNode : StatementNode
    {
        public ExpressionNode ReturnExpression { get; set; }
        public StatementNode ReturnStatement { get; set; }
        public ReturnStatementNode()
            : this(null, null) { }
        public ReturnStatementNode(ExpressionNode returnexpression, StatementNode returnstatement)
        {
            ReturnExpression = returnexpression;
            ReturnStatement = returnstatement;
        }
    }
}
