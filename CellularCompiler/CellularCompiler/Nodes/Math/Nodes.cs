
using System.Collections.Generic;

namespace CellularCompiler.Nodes
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

    internal class StringNode : ExpressionNode
    {
        public string Value { get; set; }

        public StringNode(string value)
        {
            Value = value;
        }
    }

    internal class MemberNode : ExpressionNode
    {
        public string Label { get; set; }
        public List<MemberValueNode> Values { get; set; }

        public MemberNode(string label, List<MemberValueNode> values)
        {
            Label = label;
            Values = values;
        }
    }

    internal abstract class MemberValueNode : ExpressionNode { }

    internal class ArrowValueNode : MemberValueNode
    {
        public int LeftValue { get; set; }
        public int RightValue { get; set; }

        public ArrowValueNode(int left, int right)
        {
            LeftValue = left;
            RightValue = right;
        }
    }

    internal class GridNode : ExpressionNode
    {
        public List<MemberNode> Members { get; set; }

        public GridNode(List<MemberNode> members)
        {
            Members = members;
        }
    }

}



