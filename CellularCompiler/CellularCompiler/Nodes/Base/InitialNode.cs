using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Base
{
    class InitialNode : BaseNode
    {
        public StatementNode Statement { get; set; }

        public InitialNode(StatementNode statement)
        {
            Statement = statement;
        }
    }
}
