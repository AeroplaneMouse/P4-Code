using System;
using System.Globalization;
using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Builders
{
    class BuildExpressionAst : CoronaBaseVisitor<ExpressionNode>
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
                "==" => new EqualityNode(),
                "!=" => new NotEqualNode(),
                "<" => new LessThanNode(),
                ">" => new BiggerThanNode(),
                "<=" => new LessThenOrEqualNode(),
                ">=" => new BiggerThanOrEqualNode(),
                _ => throw new ArgumentOutOfRangeException("context", "Unknown operator in switch statement - VisitInfixExpr")
            };

            // Visit the left and  of the node
            node.Left = Visit(context.left);
            node.Right = Visit(context.right);

            return node;
        }

        public override ExpressionNode VisitNumberExpr(CoronaParser.NumberExprContext context)
        {
            return new NumberNode(
                double.Parse(context.value.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent)
            );
        }

        public override ExpressionNode VisitIdentifierExpr(CoronaParser.IdentifierExprContext context)
        {
            return new IdentifierNode(context.GetText());
        }
    }
}
