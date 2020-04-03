using CellularCompiler.Nodes;

namespace CellularCompiler.Visitor
{
    internal class EvaluateExpressionVisitor : AstVisitor<double>
    {
        public override double Visit(AdditionNode node) => Visit(node.Left) + Visit(node.Right);
        public override double Visit(SubstractionNode node) => Visit(node.Left) - Visit(node.Right);
        public override double Visit(MultiplicationNode node) => Visit(node.Left) * Visit(node.Right);
        public override double Visit(DivisionNode node) => Visit(node.Left) / Visit(node.Right);

        public override double Visit(NumberNode node) => node.Value;
    }
}
