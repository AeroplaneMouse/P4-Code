
namespace CellularCompiler.Nodes
{
    internal abstract class ExpressionNode { }

    internal class InfixExpressionNode : ExpressionNode
    {
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }
    }

    internal class AdditionNode : InfixExpressionNode { }

    internal class SubstractionNode : InfixExpressionNode { }

    internal class MultiplicationNode : InfixExpressionNode { }

    internal class DivisionNode : InfixExpressionNode { }

    internal class NumberNode : ExpressionNode
    {
        public double Value { get; set; }

        public NumberNode()
            : this(0) { }

        public NumberNode(double value)
        {
            Value = value;
        }
    }
}



