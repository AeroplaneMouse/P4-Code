using CellularCompiler.Nodes.Math;
using CellularCompiler.Visitor.Math;

namespace CellularCompiler.Evaluators
{
    internal class ComparisonExpressionAstEvaluator : ComparisonExpressionAstVisitor<int, bool>
    {
        public override bool Visit(EqualityNode node)
            => Visit(node.Left as NumberNode) == Visit(node.Right as NumberNode);

        public override bool Visit(NotEqualNode node)
            => Visit(node.Left as NumberNode) != Visit(node.Right as NumberNode);

        public override bool Visit(LessThanNode node)
            => Visit(node.Left as NumberNode) < Visit(node.Right as NumberNode);

        public override bool Visit(BiggerThanNode node)
            => Visit(node.Left as NumberNode) > Visit(node.Right as NumberNode);

        public override bool Visit(LessThanOrEqualNode node)
            => Visit(node.Left as NumberNode) <= Visit(node.Right as NumberNode);

        public override bool Visit(BiggerThanOrEqualNode node)
            => Visit(node.Left as NumberNode) >= Visit(node.Right as NumberNode);

        public override int Visit(NumberNode node)
            => (int)node.Value;
    }
}
