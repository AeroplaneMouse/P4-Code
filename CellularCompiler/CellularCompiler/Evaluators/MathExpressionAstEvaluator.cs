using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Evaluators
{
    class MathExpressionAstEvaluator : MathAstVisitor<int>
    {
        public override int Visit(AdditionNode node) 
            => Visit(node.Left) + Visit(node.Right);

        public override int Visit(SubstractionNode node)
            => Visit(node.Left) - Visit(node.Right);

        public override int Visit(MultiplicationNode node)
            => Visit(node.Left) * Visit(node.Right);

        public override int Visit(DivisionNode node)
            => Visit(node.Left) / Visit(node.Right);

        public override int Visit(NumberNode node) 
            => node.Value;
    }
}
