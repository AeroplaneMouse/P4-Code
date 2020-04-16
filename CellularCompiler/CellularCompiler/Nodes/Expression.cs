using CellularCompiler.Nodes.Base;

namespace CellularCompiler.Nodes
{
    abstract class ExpressionNode : BaseNode
    { }

    class InfixExpressionNode : ExpressionNode
    {
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }

        public InfixExpressionNode(ExpressionNode left=null, ExpressionNode right=null)
        {
            Left = left;
            Right = right;
        }
    }

    class AdditionNode : InfixExpressionNode { }

    class SubstractionNode : InfixExpressionNode { }

    class MultiplicationNode : InfixExpressionNode { }

    class DivisionNode : InfixExpressionNode { }

    class NumberNode : ExpressionNode
    {
        public double Value { get; set; }

        public NumberNode()
            : this(0) { }

        public NumberNode(double value)
        {
            Value = value;
        }
    }

    class StringNode : ExpressionNode
    {
        public string Value { get; set; }

        public StringNode(string value)
        {
            Value = value;
        }
    }
}



