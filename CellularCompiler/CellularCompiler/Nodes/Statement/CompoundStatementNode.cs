using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Statement
{
    class CompoundStatementNode : StatementNode
    {
        public List<StatementNode> Statements { get; set; }

        public CompoundStatementNode()
            : this(null) { }
        public CompoundStatementNode(List<StatementNode> statements)
        {
            Statements = statements;
        }
    }
}
