using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
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

    class DivisionNode : InfixExpressionNode
    {
        public DivisionNode(ExpressionNode left=null, ExpressionNode right=null)
            : base(left,right)
        {
            // Check for possible division by zero at AST generation time
            if (right is NumberNode nNode && nNode.Value == 0)
                throw new ArgumentOutOfRangeException("right", "Division by zero not allowed");
        }
    }
}
