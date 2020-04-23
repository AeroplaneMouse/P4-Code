using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
{
    class InitialNode : BaseNode
    {
        public List<StatementNode> Statements { get; set; }

        public InitialNode(List<StatementNode> statements)
        {
            Statements = statements;
        }
    }
}
