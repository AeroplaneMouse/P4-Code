using System;
using System.Text;
using System.Collections.Generic;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Nodes.Statement
{
    class CaseStatementNode : StatementNode
    {
        public List<ValueNode> Values { get; set; }
        public StatementNode Statement { get; set; }

        public CaseStatementNode(List<ValueNode> values, StatementNode statement)
        {
            Values = values;
            Statement = statement;
        }
    }
}
