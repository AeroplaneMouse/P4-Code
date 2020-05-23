using System;
using System.Collections.Generic;
using System.Text;

namespace CI.Nodes.Math
{
    class InfixExpressionNode : ExpressionNode
    {
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }

        public InfixExpressionNode(ExpressionNode left = null, ExpressionNode right = null)
        {
            Left = left;
            Right = right;
        }
    }

    class AdditionNode : InfixExpressionNode { }

    class SubstractionNode : InfixExpressionNode { }

    class MultiplicationNode : InfixExpressionNode { }

    class DivisionNode : InfixExpressionNode { }
}
