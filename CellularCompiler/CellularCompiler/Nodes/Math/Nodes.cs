
namespace CellularCompiler.Nodes.Math
{
    internal abstract class ExpressionNode { }

    internal class InfixExpressionNode : ExpressionNode
    {
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }

        public InfixExpressionNode(ExpressionNode left=null, ExpressionNode right=null)
        {
            Left = left;
            Right = right;
        }
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



