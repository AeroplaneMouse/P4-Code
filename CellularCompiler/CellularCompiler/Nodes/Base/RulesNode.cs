using CellularCompiler.Models;
using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
{
    class RulesNode : BaseNode
    {
        public List<RuleStatementNode> RuleStatements { get; set; }

        public RulesNode(List<RuleStatementNode> ruleStatements)
        {
            RuleStatements = ruleStatements;
        }
    }
}
