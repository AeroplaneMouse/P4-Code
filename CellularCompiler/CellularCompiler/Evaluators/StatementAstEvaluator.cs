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
        Grid grid { get; }
        Cell cell { get; }

        public StatementAstEvaluator(Grid grid, Cell cell)
        {
            this.grid = grid;
            this.cell = cell;
        }

        public void Visit(StatementNode node, ICoronaEvaluator sender)
        {
            Visit((dynamic)node, sender);
        }

        public void Visit(IterationStatementNode node, ICoronaEvaluator sender)
        {
            //node.Initializer

            return;
            for(; ; )
            {
                Visit(node.Statement, sender);
            }


        }

        public void Visit(ReturnStatementNode node, ICoronaEvaluator sender)
        {
            State state = sender.GetStateByLabel(node.IdentifierLabel);
            grid.SetCell(cell, state);
        }

        public void Visit(GridAssignmentStatementNode node, ICoronaEvaluator sender)
        {
            ExpressionAstEvaluator exprEvaluator = new ExpressionAstEvaluator();

            // Extract pos
            double x = exprEvaluator.Visit(node.GridPoint.ExpressionNodes[0]);
            double y = exprEvaluator.Visit(node.GridPoint.ExpressionNodes[1]);

            // Convert to int
            int xI = (int)Math.Floor(x);
            int yI = (int)Math.Floor(y);

            // Extract result
            State state = sender.GetStateByLabel(node.IdentifierLabel);

            // Set specified cells nextState
            grid.SetCell(xI, yI, state);
        }

        public Rule VisitCaseStatementNode(CaseStatementNode node, ICoronaEvaluator sender)
        {
            List<State> ruleStates = new List<State>();

            // Foreach state label in the caseStatement, find its right state object
            foreach (string label in node.Values)
                ruleStates.Add(sender.GetStateByLabel(label));

            return new Rule(ruleStates, node.Statement);
        }

        public List<Rule> VisitRuleStatementNode(RuleStatementNode node, ICoronaEvaluator sender)
        {
            List<Rule> rules = new List<Rule>();

            // Visit each CaseStatementNode to generate rules
            foreach (CaseStatementNode csNode in node.CaseStatementNodes)
                rules.Add(VisitCaseStatementNode(csNode, sender));

            return rules;
        }

    } 
}
