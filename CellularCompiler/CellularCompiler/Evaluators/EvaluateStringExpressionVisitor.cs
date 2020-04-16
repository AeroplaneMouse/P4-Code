using CellularCompiler.Nodes;

namespace CellularCompiler.Evaluators
{
    internal class EvaluateStringExpressionVisitor
    {
        public string Visit(StringNode node)
            => node.Value;
    }
}
