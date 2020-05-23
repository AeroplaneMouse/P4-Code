using System;
using System.Text;
using System.Collections.Generic;
using CI.Nodes.Values;

namespace CI.Nodes.Statement
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
