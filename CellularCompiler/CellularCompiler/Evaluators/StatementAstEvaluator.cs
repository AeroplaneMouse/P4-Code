using CellularCompiler.Exceptions;
using CellularCompiler.Models;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Statement;
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

            return;
            for(; ; )
            {
                Visit(node.Statement);
            }


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
    } 
}
