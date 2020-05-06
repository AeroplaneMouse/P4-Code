using CellularCompiler.Exceptions;
using CellularCompiler.Models;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Statement;
using CellularCompiler.Nodes.Values;
using CellularCompiler.Visitor.Math;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CellularCompiler.Evaluators
{
    class StatementAstEvaluator
    {
        ICoronaEvaluator sender;
        Cell cell { get; }

        public StatementAstEvaluator(ICoronaEvaluator sender, Cell cell)
        {
            this.sender = sender;
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

            // We have to convert node.Conditioner as ExpressionNode returns an int because of public virtual T Visit(ExpressionNode node) in ComparisonVisitor

            for (exprEvaluator.Visit(node.Initializer); compEvaluator.Visit(node.Conditioner); exprEvaluator.Visit(node.Iterator))
            {
                Visit(node.Statement);
            }
        }

        public void Visit(MatchStatementNode node)
        {
            // Find the first caseStatement 
            CaseStatementNode caseNode = GetFirstMatchingCase(node);

            // Visit the statement inside the matching caseStatement
            if (caseNode != null)
                Visit(caseNode.Statement);
        }

        private CaseStatementNode GetFirstMatchingCase(MatchStatementNode node)
        {
            foreach (CaseStatementNode c in node.CaseStatementNodes)
                if (IsCaseMatching(c, node.Elements))
                    return c;

            return null;
        }

        private bool IsCaseMatching(CaseStatementNode c, List<ValueNode> elements)
        {
            ValueAstEvaluator valueVisitor = new ValueAstEvaluator(sender);

            int i = 0;
            foreach(ValueNode e in elements)
            {
                switch (e)
                {
                    case IdentifierValueNode t1:
                        IdentifierValueNode iden = (IdentifierValueNode)e;
                        if (iden.Label == ".state")
                        {
                            // Check if case has valid state in i'th place
                            if (c.Values[i] is IdentifierValueNode idState)
                            {
                                State state = sender.GetStateByLabel(idState.Label);
                                if (state == null || cell.State != state)
                                    return false;
                            }
                        }

                        // Handle variables
                        break;
                    case GridValueNode t2:
                        GridValueNode node = (GridValueNode)e;
                        Cell otherCell = valueVisitor.Visit(node);

                        if (node.Member == null || node.Member.Label == ".state")
                        {
                            // Check if case has valid state in i'th place
                            if (c.Values[i] is IdentifierValueNode idState)
                            {
                                State state = sender.GetStateByLabel(idState.Label);
                                if (state == null || otherCell.State != state)
                                    return false;
                            }    
                        }


                        break;
                    default:
                        //Console.WriteLine($"Case matching has yet to be implemented for: { e.GetType() }");
                        //Console.WriteLine($"Case value position: { i }");
                        throw new Exception($"Case matching has yet to be implemented for: { e.GetType() }  pos: { i }");
                }

                i++;
            }
            return true;
        }

        public void Visit(CompoundStatementNode node)
        {
            foreach (StatementNode sNode in node.Statements)
                if (!sender.ReturnStatementHasBeenHit)
                    Visit(sNode);
        }

        public void Visit(ReturnStatementNode node)
        {
            State state = sender.GetStateByLabel(node.Identifier.Label);
            sender.SetCell(cell, state);
            sender.ReturnStatementHasBeenHit = true;
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
