﻿using CI.Models;
using CI.Nodes.Math;
using CI.Exceptions;

namespace CI.Evaluators
{
    class ComparisonExpressionAstEvaluator : ComparisonExpressionAstVisitor<int, bool>
    {
        public override bool Visit(EqualityNode node)
        {
            int nodeLeft = 0;
            int nodeRight = 0;
            if (node.Left is NumberNode)
                nodeLeft = Visit(node.Left as NumberNode);
            else if (node.Left is IdentifierNode)
                nodeLeft = Visit(node.Left as IdentifierNode);
            else
                nodeLeft = Visit(node.Left as InfixExpressionNode);

            if (node.Right is NumberNode)
                nodeRight = Visit(node.Right as NumberNode);
            else if (node.Right is IdentifierNode)
                nodeRight = Visit(node.Right as IdentifierNode);
            else
                nodeRight = Visit(node.Right as InfixExpressionNode);

            return nodeLeft == nodeRight;
        }

        public override bool Visit(NotEqualNode node)
        {
            int nodeLeft = 0;
            int nodeRight = 0;
            if (node.Left is NumberNode)
                nodeLeft = Visit(node.Left as NumberNode);
            else if (node.Left is IdentifierNode)
                nodeLeft = Visit(node.Left as IdentifierNode);
            else
                nodeLeft = Visit(node.Left as InfixExpressionNode);

            if (node.Right is NumberNode)
                nodeRight = Visit(node.Right as NumberNode);
            else if (node.Right is IdentifierNode)
                nodeRight = Visit(node.Right as IdentifierNode);
            else
                nodeRight = Visit(node.Right as InfixExpressionNode);

            return nodeLeft != nodeRight;
        }

        public override bool Visit(LessThanNode node)
        {
            int nodeLeft = 0;
            int nodeRight = 0;
            if (node.Left is NumberNode)
                nodeLeft = Visit(node.Left as NumberNode);
            else if (node.Left is IdentifierNode)
                nodeLeft = Visit(node.Left as IdentifierNode);
            else
                nodeLeft = Visit(node.Left as InfixExpressionNode);

            if (node.Right is NumberNode)
                nodeRight = Visit(node.Right as NumberNode);
            else if (node.Right is IdentifierNode)
                nodeRight = Visit(node.Right as IdentifierNode);
            else
                nodeRight = Visit(node.Right as InfixExpressionNode);

            return nodeLeft < nodeRight;
        }

        public override bool Visit(BiggerThanNode node)
        {
            int nodeLeft = 0;
            int nodeRight = 0;
            if (node.Left is NumberNode)
                nodeLeft = Visit(node.Left as NumberNode);
            else if (node.Left is IdentifierNode)
                nodeLeft = Visit(node.Left as IdentifierNode);
            else
                nodeLeft = Visit(node.Left as InfixExpressionNode);

            if (node.Right is NumberNode)
                nodeRight = Visit(node.Right as NumberNode);
            else if (node.Right is IdentifierNode)
                nodeRight = Visit(node.Right as IdentifierNode);
            else
                nodeRight = Visit(node.Right as InfixExpressionNode);

            return nodeLeft > nodeRight;
        }

        public override bool Visit(LessThanOrEqualNode node)
        {
            int nodeLeft = 0;
            int nodeRight = 0;
            if (node.Left is NumberNode)
                nodeLeft = Visit(node.Left as NumberNode);
            else if (node.Left is IdentifierNode)
                nodeLeft = Visit(node.Left as IdentifierNode);
            else
                nodeLeft = Visit(node.Left as InfixExpressionNode);

            if (node.Right is NumberNode)
                nodeRight = Visit(node.Right as NumberNode);
            else if (node.Right is IdentifierNode)
                nodeRight = Visit(node.Right as IdentifierNode);
            else
                nodeRight = Visit(node.Right as InfixExpressionNode);

            return nodeLeft <= nodeRight;
        }

        public override bool Visit(BiggerThanOrEqualNode node)
        {
            int nodeLeft = 0;
            int nodeRight = 0;
            if (node.Left is NumberNode)
                nodeLeft = Visit(node.Left as NumberNode);
            else if (node.Left is IdentifierNode)
                nodeLeft = Visit(node.Left as IdentifierNode);
            else
                nodeLeft = Visit(node.Left as InfixExpressionNode);

            if (node.Right is NumberNode)
                nodeRight = Visit(node.Right as NumberNode);
            else if (node.Right is IdentifierNode)
                nodeRight = Visit(node.Right as IdentifierNode);
            else
                nodeRight = Visit(node.Right as InfixExpressionNode);

            return nodeLeft >= nodeRight;
        }

        public override int Visit(IdentifierNode node)
        {
            Symbol sym = Stbl.st.Retrieve(node.Label);

            if (sym != null)
            {
                if (sym is VariableSymbol<int> intVar)
                    return intVar.Value;
                else
                    throw new TheLanguageErrorException($"Unexpected type in comparison expression. Expected Int got { sym.ToString() }");
            }
            else
                throw new TheLanguageErrorException($"Undeclared variable { node.Label }");
        }

        public override int Visit(InfixExpressionNode node)
        {
            MathExpressionAstEvaluator expressionAstEvaluator = new MathExpressionAstEvaluator();
            return expressionAstEvaluator.Visit(node);
        }

        public override int Visit(NumberNode node)
            => node.Value;

    }
}
