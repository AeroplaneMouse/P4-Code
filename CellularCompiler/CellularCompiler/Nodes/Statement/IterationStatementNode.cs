using System;
using System.Text;
using System.Collections.Generic;
using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Nodes.Statement
{
    class IterationStatementNode : StatementNode
    {
        public ExpressionNode Initializer { get; set; }
        public ExpressionNode Conditioner { get; set; }
        public ExpressionNode Iterator { get; set; }
        public StatementNode Statement { get; set; }

        public IterationStatementNode()
            : this(null, null, null, null) { }

        public IterationStatementNode(ExpressionNode initializer, ExpressionNode conditioner, ExpressionNode iterator, StatementNode statement)
        {
            Initializer = initializer;
            Conditioner = conditioner;
            Iterator = iterator;
            Statement = statement;
        }
    }
}
