using CellularCompiler.Models;
using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
{
    class RulesNode : BaseNode
    {
        public List<StatementNode> Statements { get; set; }

        public RulesNode(List<StatementNode> statements)
        {
            Statements = statements;
        }
    }
}
