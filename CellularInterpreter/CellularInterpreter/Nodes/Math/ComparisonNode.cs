namespace CI.Nodes.Math
{
    class ComparisonNode : ExpressionNode
    {
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }

        public ComparisonNode(ExpressionNode left = null, ExpressionNode right = null)
        {
            Left = left;
            Right = right;
        }
    }

    class EqualityNode : ComparisonNode { }

    class NotEqualNode : ComparisonNode { }

    class LessThanNode : ComparisonNode{ }

    class BiggerThanNode : ComparisonNode { }

    class LessThanOrEqualNode : ComparisonNode { }

    class BiggerThanOrEqualNode : ComparisonNode { }
}
