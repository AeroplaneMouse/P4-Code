using System;
using System.Globalization;
using CellularCompiler.Nodes;

namespace CellularCompiler.Builders
{
    class BuildExpressionVisitor : CoronaBaseVisitor<ExpressionNode>
    {
        public override ExpressionNode VisitInfixExpr(CoronaParser.InfixExprContext context)
        {
            // Get infix expression node type
            InfixExpressionNode node = context.op.GetText() switch
            {
                "+" => new AdditionNode(),
                "-" => new SubstractionNode(),
                "*" => new MultiplicationNode(),
                "/" => new DivisionNode(),
                _ => throw new ArgumentOutOfRangeException("context", "Unknown operator in switch statement - VisitInfixExpr")
            };

            // Visit the left and  of the node
            node.Left = Visit(context.left);
            node.Right = Visit(context.right);

            return node;
        }

        public override ExpressionNode VisitStringExpr(CoronaParser.StringExprContext context)
        {
            return new StringNode(context.value.Text);
        }

        public override ExpressionNode VisitNumberExpr(CoronaParser.NumberExprContext context)
        {
            return new NumberNode(
                double.Parse(context.value.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent)
            );
        }
    }
}
