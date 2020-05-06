using System;
using System.Text;
using System.Windows.Markup;
using System.Collections.Generic;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Nodes.Statement
{
    class MatchStatementNode : StatementNode
    {
        public List<ValueNode> Elements { get; set; }
        public List<CaseStatementNode> CaseStatementNodes { get; set; }

        public MatchStatementNode(List<ValueNode> elements, List<CaseStatementNode> caseStatementNodes)
        {
            Elements = elements;
            CaseStatementNodes = caseStatementNodes;
        }
    }
}
