using System;
using System.Text;
using System.Collections.Generic;
using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Nodes.Statement
{
    class IterationStatementNode : StatementNode
    {
        public ExpressionNode Conditioner { get; set; }
        public StatementNode Statement { get; set; }

        public IterationStatementNode()
            : this(null, null) { }

        public IterationStatementNode(ExpressionNode conditioner, StatementNode statement)
        {
            Conditioner = conditioner;
            Statement = statement;
        }
    }
}
