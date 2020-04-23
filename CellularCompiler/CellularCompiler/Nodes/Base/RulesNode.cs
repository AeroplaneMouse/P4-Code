using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
{
    class RulesNode : BaseNode
    {
        public List<SelectionStatementNode> Statements { get; set; }

        public RulesNode(List<SelectionStatementNode> statements)
        {
            Statements = statements;
        }
    }
}
