using CellularCompiler.Nodes;

namespace CellularCompiler.Visitor
{
    internal abstract class AstVisitor<T>
    {
        public abstract T Visit(AdditionNode node);
        public abstract T Visit(SubstractionNode node);
        public abstract T Visit(MultiplicationNode node);
        public abstract T Visit(DivisionNode node);
        public abstract T Visit(NumberNode node);

        public T Visit(ExpressionNode node)
        {
            return Visit((dynamic)node);
        }
    }
}
