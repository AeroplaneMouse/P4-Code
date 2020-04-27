using System;
using System.Collections.Generic;
using System.Text;
using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Nodes.Statement
{
    class SelectionStatementNode : StatementNode
    {
        public ExpressionNode SelectionExpression { get; set; }
        public StatementNode ReturnStatement { get; set; }
        public SelectionStatementNode()
            : this(null, null) { }
        public SelectionStatementNode(ExpressionNode returnexpression, StatementNode returnstatement)
        {
            //ReturnExpression = returnexpression;!!!ER IKKE LAVET KORREKT!!!
            ReturnStatement = returnstatement;
        }
    }
}
