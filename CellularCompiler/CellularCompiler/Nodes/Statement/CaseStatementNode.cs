using CellularCompiler.Nodes.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Statement
{
    class CaseStatementNode : StatementNode
    {
        public List<MemberValueNode> Values { get; set; }
        public StatementNode Statement { get; set; }
        public CaseStatementNode(List<MemberValueNode> values, StatementNode statement)
        {
            Values = values;
            Statement = statement;
        }
    }
}
