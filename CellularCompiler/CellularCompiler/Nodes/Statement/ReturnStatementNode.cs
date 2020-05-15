using System;
using System.Collections.Generic;
using System.Text;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Nodes.Statement
{
    class ReturnStatementNode : StatementNode
    {
        public IdentifierValueNode Identifier { get; set; }

        public ReturnStatementNode(IdentifierValueNode id)
        {
            Identifier = id;
        }
    }
}
