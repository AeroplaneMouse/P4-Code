using CellularCompiler.Models;
using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Evaluators
{
    class StatementAstEvaluator
    {
        Grid grid { get; }

        public StatementAstEvaluator(ref Grid grid, Cell cell)
        {
            this.grid = grid;
        }

        public void Visit(StatementNode node)
        {
            Visit((dynamic)node);
        }

        public void Visit(IterationStatementNode node)
        {
            //node.Initializer

            return;
            for(; ; )
            {
                Visit(node.Statement);
            }


        }

        public void Visit(AssignmentStatementNode node)
        {
            ExpressionAstEvaluator exprEvaluator = new ExpressionAstEvaluator();

            // Extract pos
            double x = exprEvaluator.Visit(node.GridPoint.ExpressionNodes[0]);
            double y = exprEvaluator.Visit(node.GridPoint.ExpressionNodes[1]);

            // Convert to int
            int xI = (int)Math.Floor(x);
            int yI = (int)Math.Floor(y);

            // Extract result
            double result = exprEvaluator.Visit(node.ExpressionNode);

            // Convert result to int, for now
            // TODO: This should be some sort of state
            int resultI = (int)Math.Floor(result);

            // Set specified cells nextState
            grid.SetCell(xI, yI, resultI);
        }

        public void Visit(SelectionStatementNode node)
        {
            throw new NotImplementedException();
            //node.MatchOnState;

            //node.MemberIDs;
            //node.CaseStatements;

            


        }
    } 
}
