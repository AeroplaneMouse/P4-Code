using CellularCompiler.Nodes.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Statement
{
    class CaseStatementNode : StatementNode
    {
        public List<string> Values { get; set; }
        public StatementNode Statement { get; set; }

        public CaseStatementNode(List<string> values, StatementNode statement)
        {
            Values = values;
            Statement = statement;
        }
    }
}
