using System;
using System.Globalization;
using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Visitor.Math
{
    internal class BuildMathAstVisitor : MathBaseVisitor<ExpressionNode>
    {
        public override ExpressionNode VisitMain(MathParser.MainContext context)
        {
            return Visit(context.expr());
        }

        public override ExpressionNode VisitInfixExpr(MathParser.InfixExprContext context)
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
            node.Left = Visit(context.Left);
            node.Right = Visit(context.Right);

            return node;
        }

        public override ExpressionNode VisitNumberExpr(MathParser.NumberExprContext context)
        {
            return new NumberNode(
                Int32.Parse(context.value.Text)
            );
        }
    }
}
