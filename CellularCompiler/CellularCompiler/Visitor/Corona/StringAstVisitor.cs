using CellularCompiler.Nodes;

namespace CellularCompiler.Visitor.Corona
{
    internal abstract class StringAstVisitor<T>
    {
        public abstract T Visit(StringNode node);

        public virtual T Visit(ExpressionNode node)
        {
            return Visit((dynamic)node);
        }
    }
}
