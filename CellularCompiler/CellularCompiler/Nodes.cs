using System;




internal abstract class ExpressionNode
{
}

internal class InfixExpressionNode : ExpressionNode
{
    public ExpressionNode Left { get; set; }
    public ExpressionNode Right { get; set; }
}

internal class SubstractionNode : InfixExpressionNode { }

internal class AdditionNode : InfixExpressionNode { }

internal class NumberNode : ExpressionNode
{
    public double Value { get; set; }
}

