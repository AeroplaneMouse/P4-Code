﻿using CellularCompiler.Models;
using CellularCompiler.Nodes.Math;
using System;

namespace CellularCompiler.Evaluators
{
    class MathExpressionAstEvaluator : MathAstVisitor<int>
    {
        private ICoronaEvaluator sender;

        public MathExpressionAstEvaluator(ICoronaEvaluator sender)
        {
            this.sender = sender;
        }

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
                    throw new Exception("Wrong type!");
            }
            else
                throw new Exception("FUUCK");



            //Cell cell = sender.GetCurrentCell();
            //return node.Label switch
            //{
            //    ".x" => cell.Pos.X,
            //    ".y" => cell.Pos.Y,
            //    _ => throw new ArgumentOutOfRangeException($"Unknown cell position: { node.Label }")
            //};
        }
    }
}
