using CellularCompiler.Models;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Visitor.Math;
using System;

namespace CellularCompiler.Evaluators
{
    internal class ComparisonExpressionAstEvaluator : ComparisonExpressionAstVisitor<int, bool>
    {
        public override bool Visit(EqualityNode node)
        {
            if (node.Left is NumberNode && node.Right is NumberNode)
                return Visit(node.Left as NumberNode) == Visit(node.Right as NumberNode);
            else if (node.Left is IdentifierNode && node.Right is NumberNode)
                return Visit(node.Left as IdentifierNode) == Visit(node.Right as NumberNode);
            else if (node.Left is NumberNode && node.Right is IdentifierNode)
                return Visit(node.Left as NumberNode) == Visit(node.Right as IdentifierNode);
            else
                return Visit(node.Left as IdentifierNode) == Visit(node.Right as IdentifierNode);
        }

        public override bool Visit(NotEqualNode node)
        {
            if (node.Left is NumberNode && node.Right is NumberNode)
                return Visit(node.Left as NumberNode) != Visit(node.Right as NumberNode);
            else if (node.Left is IdentifierNode && node.Right is NumberNode)
                return Visit(node.Left as IdentifierNode) != Visit(node.Right as NumberNode);
            else if (node.Left is NumberNode && node.Right is IdentifierNode)
                return Visit(node.Left as NumberNode) != Visit(node.Right as IdentifierNode);
            else
                return Visit(node.Left as IdentifierNode) != Visit(node.Right as IdentifierNode);
        }

        public override bool Visit(LessThanNode node)
        {
            if (node.Left is NumberNode && node.Right is NumberNode)
                return Visit(node.Left as NumberNode) < Visit(node.Right as NumberNode);
            else if (node.Left is IdentifierNode && node.Right is NumberNode)
                return Visit(node.Left as IdentifierNode) < Visit(node.Right as NumberNode);
            else if (node.Left is NumberNode && node.Right is IdentifierNode)
                return Visit(node.Left as NumberNode) < Visit(node.Right as IdentifierNode);
            else
                return Visit(node.Left as IdentifierNode) < Visit(node.Right as IdentifierNode);
        }

        public override bool Visit(BiggerThanNode node)
        {
            if (node.Left is NumberNode && node.Right is NumberNode)
                return Visit(node.Left as NumberNode) > Visit(node.Right as NumberNode);
            else if (node.Left is IdentifierNode && node.Right is NumberNode)
                return Visit(node.Left as IdentifierNode) > Visit(node.Right as NumberNode);
            else if (node.Left is NumberNode && node.Right is IdentifierNode)
                return Visit(node.Left as NumberNode) > Visit(node.Right as IdentifierNode);
            else
                return Visit(node.Left as IdentifierNode) > Visit(node.Right as IdentifierNode);
        }

        public override bool Visit(LessThanOrEqualNode node)
        {
            if (node.Left is NumberNode && node.Right is NumberNode)
                return Visit(node.Left as NumberNode) <= Visit(node.Right as NumberNode);
            else if (node.Left is IdentifierNode && node.Right is NumberNode)
                return Visit(node.Left as IdentifierNode) <= Visit(node.Right as NumberNode);
            else if (node.Left is NumberNode && node.Right is IdentifierNode)
                return Visit(node.Left as NumberNode) <= Visit(node.Right as IdentifierNode);
            else
                return Visit(node.Left as IdentifierNode) <= Visit(node.Right as IdentifierNode);
        }

        public override bool Visit(BiggerThanOrEqualNode node)
        {
            if (node.Left is NumberNode && node.Right is NumberNode)
                return Visit(node.Left as NumberNode) >= Visit(node.Right as NumberNode);
            else if (node.Left is IdentifierNode && node.Right is NumberNode)
                return Visit(node.Left as IdentifierNode) >= Visit(node.Right as NumberNode);
            else if (node.Left is NumberNode && node.Right is IdentifierNode)
                return Visit(node.Left as NumberNode) >= Visit(node.Right as IdentifierNode);
            else
                return Visit(node.Left as IdentifierNode) >= Visit(node.Right as IdentifierNode);
        }

        public override int Visit(IdentifierNode node)
        {
            Symbol sym = Stbl.st.Retrieve(node.Label);

            if (sym != null)
            {
                if (sym is VariableSymbol<int> intVar)
                    return intVar.Value;
                else
                    throw new Exception("Wrong type!");
            }
            else
                throw new Exception("FUUCK");
        }

        public override int Visit(NumberNode node)
            => (int)node.Value;

    }
}
