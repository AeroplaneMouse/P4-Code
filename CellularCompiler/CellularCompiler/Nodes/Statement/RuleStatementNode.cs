using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Statement
{
    class RuleStatementNode : StatementNode
    {
        public List<CaseStatementNode> CaseStatementNodes { get; set; }

        public RuleStatementNode(List<CaseStatementNode> caseStatementNodes)
        {
            CaseStatementNodes = caseStatementNodes;
        }

    }
}
