using CI.Exceptions;
using CI.Models;
using CI.Nodes.Math;

namespace CI.Evaluators
{
    class MathExpressionAstEvaluator : MathAstVisitor<int>
    {
        public override int Visit(AdditionNode node) 
            => Visit(node.Left) + Visit(node.Right);

        public override int Visit(SubstractionNode node)
            => Visit(node.Left) - Visit(node.Right);

        public override int Visit(MultiplicationNode node)
            => Visit(node.Left) * Visit(node.Right);

        public override int Visit(DivisionNode node)
            => Visit(node.Left) / Visit(node.Right);

        public override int Visit(NumberNode node) 
            => node.Value;

        public override int Visit(IdentifierNode node)
        {
            Symbol sym = Stbl.st.Retrieve(node.Label);

            if (sym != null)
            {
                if (sym is VariableSymbol<int> intVar)
                    return intVar.Value;
                else
                    throw new TheLanguageErrorException($"Unexpected type in arithmetic expression. Expected Int got { sym.ToString() }");
            }
            else
                throw new TheLanguageErrorException($"Undeclared variable { node.Label }");
        }
    }
}
