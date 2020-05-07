using CellularCompiler.Exceptions;
using CellularCompiler.Models;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Statement;
using CellularCompiler.Visitor.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Evaluators
{
    class StatementAstEvaluator
    {
        ICoronaEvaluator sender;
        Grid grid { get; }
        Cell cell { get; }

        public StatementAstEvaluator(ICoronaEvaluator sender, Grid grid, Cell cell)
        {
            this.sender = sender;
            this.grid = grid;
            this.cell = cell;
        }

        public void Visit(StatementNode node)
        {
            Visit((dynamic)node);
        }

        public void Visit(IterationStatementNode node)
        {
            //node.Initializer
            MathExpressionAstEvaluator exprEvaluator = new MathExpressionAstEvaluator();
            ComparisonExpressionAstEvaluator compEvaluator = new ComparisonExpressionAstEvaluator();

            // We have to convert node.Conditioner as ExpressionNode returns an int because of public virtual T Visit(ExpressionNode node) in ComparisonVisitor'
            int i = 0;
            while (compEvaluator.Visit(node.Conditioner))
            {
                Visit(node.Statement);
            }
        }

        public void Visit(MatchStatementNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(CompoundStatementNode node)
        {
            foreach (StatementNode sNode in node.Statements)
                Visit(sNode);
        }

        public void Visit(ReturnStatementNode node)
        {
            //State state = sender.GetStateByLabel(node.IdentifierLabel);
            //grid.SetCell(cell, state);
            throw new NotImplementedException();
        }

        public void Visit(GridAssignmentStatementNode node)
        {
            ValueAstEvaluator valueVisitor = new ValueAstEvaluator(sender);

            Cell c = valueVisitor.Visit(node.GridPoint);
                     

            // Extract result
            State state = sender.GetStateByLabel(node.Identifier.Label);

            // Set specified cells nextState
            sender.SetCell(c, state);
        }

        public void Visit(IdentifierAssignmentStatementNode node)
        {
            object exprResult = null;

            if (node.Expression is ComparisonNode)
                exprResult = new ComparisonExpressionAstEvaluator().Visit(node.Expression);
            else
                exprResult = new MathExpressionAstEvaluator().Visit(node.Expression);

            Console.WriteLine($"Expression result: { exprResult }");
        }
    } 
}
