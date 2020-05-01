using System;
using System.Collections.Generic;
using System.Text;
using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Nodes.Statement
{
    class ReturnStatementNode : StatementNode
    {
        public string IdentifierLabel { get; set; }

        public ReturnStatementNode(string identifierLabel)
        {
            IdentifierLabel = identifierLabel;
        }
    }
}
