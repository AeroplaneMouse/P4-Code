using Antlr4.Runtime;
using System;
using System.Globalization;
using System.Reflection;

internal class BuildAstVisitor : MathBaseVisitor<ExpressionNode>
{
    public override ExpressionNode VisitMain(MathParser.MainContext context)
    {
        return Visit(context.expr());
    }

    public override ExpressionNode VisitInfixExpr(MathParser.InfixExprContext context)
    {

        InfixExpressionNode node = new InfixExpressionNode();

        MathLexer.ADD
        string test = context.op.ToString();


        switch (context.op.GetType)
        {
            case MathLexer.ADD:
                node = new AdditionNode();
                break;
        }

        //switch (context.op)
        //{
        //    case
        //}

        return node;

        //AdditionNode thing = new AdditionNode();
        //node.Left = Visit(context.Left);
        //node.Right = Visit(context.Right);

        //return node;
    }


    public override ExpressionNode VisitNumberExpr(MathParser.NumberExprContext context)
    {
        return new NumberNode
        {
            Value = double.Parse(context.value.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent)
        };
    }
}