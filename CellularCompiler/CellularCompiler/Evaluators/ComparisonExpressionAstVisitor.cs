using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Evaluators
{
    internal abstract class ComparisonExpressionAstVisitor<T, U>
    {
        public abstract U Visit(EqualityNode node);
        public abstract U Visit(NotEqualNode node);
        public abstract U Visit(LessThanNode node);
        public abstract U Visit(BiggerThanNode node);
        public abstract U Visit(LessThanOrEqualNode node);
        public abstract U Visit(BiggerThanOrEqualNode node);
        public abstract T Visit(NumberNode node);
        public abstract T Visit(IdentifierNode node);
        public abstract T Visit(InfixExpressionNode node);

        public virtual U Visit(ExpressionNode node)
        {
            return Visit((dynamic)node);
        }
    }
}
