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
using System.Threading;

namespace CellularCompiler.Evaluators
{
    class StatementAstEvaluator
    {
        readonly ICoronaEvaluator sender;

        public StatementAstEvaluator(ICoronaEvaluator sender)
        {
            this.sender = sender;
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
            // Find the first caseStatement 
            CaseStatementNode caseNode = GetFirstMatchingCase(node);

            // Visit the statement inside the matching caseStatement
            if (caseNode != null)
                Visit(caseNode.Statement);
        }

        public void Visit(CompoundStatementNode node)
        {
            Stbl.st.OpenScope();

            foreach (StatementNode sNode in node.Statements)
                if (!sender.ReturnStatementHasBeenHit)
                    Visit(sNode);

            Stbl.st.CloseScope();
        }

        public void Visit(ReturnStatementNode node)
        {
            Cell cell = sender.GetCurrentCell();
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
            // Evaluate expression
            object exprResult = null;
            if (node.Expression is ComparisonNode)
                exprResult = new ComparisonExpressionAstEvaluator().Visit(node.Expression);
            else
                exprResult = new MathExpressionAstEvaluator().Visit(node.Expression);

            // Insert into symbol table
            Symbol sym = Stbl.st.Retrieve(node.Identifier.Label);
            if (sym != null)
            {
                if (sym is VariableSymbol<int> intVar)
                    intVar.Value = (int)exprResult;
                else if (sym is VariableSymbol<bool> boolVar)
                    boolVar.Value = (bool)exprResult;
            }
            else
            {
                switch (exprResult)
                {
                    case int t:
                        Stbl.st.Insert(new VariableSymbol<int>(t, node.Identifier.Label));
                        break;
                    case bool t:
                        Stbl.st.Insert(new VariableSymbol<bool>(t, node.Identifier.Label));
                        break;
                }
            }
        }


        private CaseStatementNode GetFirstMatchingCase(MatchStatementNode node)
        {
            ValueAstEvaluator valueVisitor = new ValueAstEvaluator(sender);
            List<ValueNode> values = new List<ValueNode>();
            Cell cell = sender.GetCurrentCell();

            // Evaluate elements
            int i = 0;
            foreach (var element in node.Elements)
            {
                switch (element)
                {
                    case IdentifierValueNode t1:
                        IdentifierValueNode idNode = (IdentifierValueNode)element;
                        values.Add(idNode.Label switch
                        {
                            ".state" => new StateValueNode(cell.State),
                            ".x" => new IntValueNode(cell.Pos.X),
                            ".y" => new IntValueNode(cell.Pos.Y),
                            _ => throw new ArgumentException("Unknown identifier")
                        });
                        break;
                    case GridValueNode t2:
                        GridValueNode gridNode = (GridValueNode)element;
                        Cell otherCell = valueVisitor.Visit(gridNode);
                        values.Add(new StateValueNode(otherCell.State));
                        break;
                    default:
                        throw new Exception($"Case matching has yet to be implemented for MatchElement: [{ i }] { element.GetType() }");
                }

                i++;
            }

            // Find first matching case
            foreach (CaseStatementNode c in node.CaseStatementNodes)
                if (IsCaseMatching(c, values))
                    return c;

            return null;
        }

        private bool IsCaseMatching(CaseStatementNode c, List<ValueNode> elementValues)
        {
            ValueAstEvaluator valueVisitor = new ValueAstEvaluator(sender);

            // Match each value in case
            int i = 0;
            foreach (ValueNode value in c.Values)
            {

                switch (value)
                {
                    case IdentifierValueNode t:
                        IdentifierValueNode idNode = (IdentifierValueNode)value;
                        if (IsState(idNode, out State state))
                        {
                            if (!elementValues[i].Equals(state))
                                return false;
                        }
                        break;

                    case IntValueNode t:
                        IntValueNode intNode = (IntValueNode)value;
                        if (!elementValues[i].Equals(intNode))
                            return false;
                        break;

                    case ArrowValueNode t:
                        ArrowValueNode arrowNode = (ArrowValueNode)value;
                        // Check if elementvalue falls inside arrow value span
                        if (!elementValues[i].Equals(arrowNode))
                            return false;
                        break;

                    case DefaultValueNode t:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Case matching has yet to be implemented for CaseValue: [{ i }] { value.GetType() }");
                }

                i++;
            }

            return true;
        }

        /// <summary>
        /// Check wheter or not an IdentifierNode, could be representing a state
        /// </summary>
        /// <param name="node">IdentifierValueNode to be checked</param>
        /// <param name="state">If a state was found, this would have the resulting state</param>
        /// <returns>True if a state could be extracted from the giving IdentifierValueNode</returns>
        private bool IsState(IdentifierValueNode node, out State state)
        {
            state = sender.GetStateByLabel(node.Label);
            return state != null;
        }
    } 
}
