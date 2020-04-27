using System;
using System.Collections.Generic;
using System.Text;
using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Nodes.Statement
{
    class ReturnStatementNode : StatementNode
    {
        public ExpressionNode ReturnExpression { get; set; }
        public ReturnStatementNode()
            : this(null) { }
        public ReturnStatementNode(ExpressionNode returnexpression)
        {
            ReturnExpression = returnexpression;
        }
    }
}
