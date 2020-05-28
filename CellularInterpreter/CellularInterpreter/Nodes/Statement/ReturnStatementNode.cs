using System;
using System.Collections.Generic;
using System.Text;
using CI.Nodes.Math;
using CI.Nodes.Values;

namespace CI.Nodes.Statement
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
