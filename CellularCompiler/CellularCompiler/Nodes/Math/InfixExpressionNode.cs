using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Math
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

    class EqualityNode : InfixExpressionNode { }

    class NotEqualNode : InfixExpressionNode { }

    class LessThanNode : InfixExpressionNode { }

    class BiggerThanNode : InfixExpressionNode { }

    class LessThenOrEqualNode : InfixExpressionNode { }

    class BiggerThanOrEqualNode : InfixExpressionNode { }
}
