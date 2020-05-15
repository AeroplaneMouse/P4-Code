using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Evaluators
{
    internal abstract class MathAstVisitor<T>
    {
        public abstract T Visit(AdditionNode node);
        public abstract T Visit(SubstractionNode node);
        public abstract T Visit(MultiplicationNode node);
        public abstract T Visit(DivisionNode node);

        public abstract T Visit(NumberNode node);

        public abstract T Visit(IdentifierNode node);

        public virtual T Visit(ExpressionNode node)
        {
            return Visit((dynamic)node);
        }
    }
}
