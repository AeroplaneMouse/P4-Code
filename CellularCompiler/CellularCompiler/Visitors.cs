using System;
using Antlr4.Runtime;
using System.Reflection;
using System.Globalization;
using CellularCompiler.Nodes;

internal class BuildAstVisitor : MathBaseVisitor<ExpressionNode>
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
            _ => throw new ArgumentOutOfRangeException("context", "Unknown operator in switch statement - VisitInfixExpr")
        };

        // Visit the left and  of the node
        node.Left = Visit(context.Left);
        node.Right = Visit(context.Right);

        return node;
    }


    public override ExpressionNode VisitNumberExpr(MathParser.NumberExprContext context)
    {
        return new NumberNode
        {
            Value = double.Parse(context.value.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent)
        };
    }
}