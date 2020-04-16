using CellularCompiler.Nodes;
using CellularCompiler.Visitor.Corona;

namespace CellularCompiler.Evaluators
{
    internal class EvaluateMathExpressionVisitor : MathAstVisitor<double>
    {
        public override double Visit(AdditionNode node) 
            => Visit(node.Left) + Visit(node.Right);

        public override double Visit(SubstractionNode node)
            => Visit(node.Left) - Visit(node.Right);

        public override double Visit(MultiplicationNode node)
            => Visit(node.Left) * Visit(node.Right);

        public override double Visit(DivisionNode node)
            => Visit(node.Left) / Visit(node.Right);

        public override double Visit(NumberNode node) 
            => node.Value;
    }
}
