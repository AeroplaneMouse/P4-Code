using CellularCompiler.Nodes;

namespace CellularCompiler.Visitor.Corona
{
    internal class EvaluateStringExpressionVisitor : StringAstVisitor<string>
    {
        public override string Visit(StringNode node)
            => node.Value;
    }
}
