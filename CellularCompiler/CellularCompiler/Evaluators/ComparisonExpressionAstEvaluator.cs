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
            if (node.Left is NumberNode nNode)
                return Visit(nNode) == Visit(node.Right as NumberNode);
            else
            {
                return Visit(node.Left as IdentifierNode) == Visit(node.Right as NumberNode);
            }

        }

        public override bool Visit(NotEqualNode node)
            => Visit(node.Left as NumberNode) != Visit(node.Right as NumberNode);

        public override bool Visit(LessThanNode node)
        {
            if (node.Left is NumberNode nNode)
                return Visit(node.Left as NumberNode) < Visit(node.Right as NumberNode);
            else
                return Visit(node.Left as IdentifierNode) < Visit(node.Right as NumberNode);
        }

        public override bool Visit(BiggerThanNode node)
            => Visit(node.Left as NumberNode) > Visit(node.Right as NumberNode);

        public override bool Visit(LessThanOrEqualNode node)
            => Visit(node.Left as NumberNode) <= Visit(node.Right as NumberNode);

        public override bool Visit(BiggerThanOrEqualNode node)
            => Visit(node.Left as NumberNode) >= Visit(node.Right as NumberNode);

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
