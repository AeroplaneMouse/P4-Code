using System;
using System.Globalization;
using CI.Nodes.Math;
using CI.Nodes.Values;

namespace CI.Builders
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
                _ => throw new ArgumentOutOfRangeException("context", "Unknown operator in switch statement - VisitInfixExpr")
            };

            // Visit the left and  of the node
            node.Left = Visit(context.left);
            node.Right = Visit(context.right);

            return node;
        }

        public override ExpressionNode VisitComparisonExpr(CoronaParser.ComparisonExprContext context)
        {
            ComparisonNode node = context.op.GetText() switch
            {
                "==" => new EqualityNode(),
                "!=" => new NotEqualNode(),
                "<" => new LessThanNode(),
                ">" => new BiggerThanNode(),
                "<=" => new LessThanOrEqualNode(),
                ">=" => new BiggerThanOrEqualNode(),
                _ => throw new ArgumentOutOfRangeException("context", "Unknown operator in switch statement - VisitComparisonExpr")
            };

            node.Left = Visit(context.left);
            node.Right = Visit(context.right);

            return node;
        }

        public override ExpressionNode VisitNumberExpr(CoronaParser.NumberExprContext context)
        {
            return new NumberNode(
                Int32.Parse(context.intValue().GetText())
            );

            //BuildValueAst valueVisitor = new BuildValueAst();
            //return valueVisitor.Visit(context);
            throw new NotImplementedException();
        }

        public override ExpressionNode VisitIdentifierExpr(CoronaParser.IdentifierExprContext context)
        {
            return new IdentifierNode(context.GetText());
        }
    }
}
