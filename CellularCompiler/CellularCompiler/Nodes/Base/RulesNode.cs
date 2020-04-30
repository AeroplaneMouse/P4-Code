using CellularCompiler.Models;
using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
{
    class RulesNode : BaseNode
    {
        public List<SelectionStatementNode> Statements { get; set; }
        public List<Rule> Rules { get; set; }

        public RulesNode(List<Rule> rules)
        {
            Rules = rules;
        }
    }
}
