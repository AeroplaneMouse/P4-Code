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
using System.Windows.Markup;

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
            ComparisonExpressionAstEvaluator compEvaluator = new ComparisonExpressionAstEvaluator();

            while (compEvaluator.Visit(node.Conditioner))
                Visit(node.Statement);
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

            // Evaluate each statement inside the compoundStatement
            foreach (StatementNode sNode in node.Statements)
                if (!sender.ReturnStatementHasBeenHit)
                    Visit(sNode);

            Stbl.st.CloseScope();
        }

        public void Visit(ReturnStatementNode node)
        {
            Cell cell = sender.GetCurrentCell();
            Symbol state = Stbl.st.Retrieve(node.Identifier.Label);

            if (state is StateSymbol s)
                sender.SetCell(cell, s);
            else
                throw new Exception("Unexpected type in return statement. Must be of type STATE");

            sender.ReturnStatementHasBeenHit = true;
        }

        public void Visit(GridAssignmentStatementNode node)
        {
            ValueAstEvaluator valueVisitor = new ValueAstEvaluator(sender);

            Cell c = valueVisitor.Visit(node.GridPoint);

            // Extract result
            Symbol state = Stbl.st.Retrieve(node.Identifier.Label);

            if (state is StateSymbol s)
                sender.SetCell(c, s);
            else
                throw new Exception("Type mismatch");
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

            // Evaluate elements
            int i = 0;
            foreach (var element in node.Elements)
            {
                switch (element)
                {
                    case IdentifierValueNode t:
                        AddIdentifierElement(t, values);
                        break;
                    case IdentifierNode t:
                        AddIdentifierElement(new IdentifierValueNode(t.Label), values);
                        break;
                    case GridValueNode t:
                        Cell otherCell = valueVisitor.Visit(t);
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

        private void AddIdentifierElement(IdentifierValueNode node, List<ValueNode> values)
        {
            Symbol sym = Stbl.st.Retrieve(node.Label);

            if (sym != null)
            {
                values.Add(sym switch
                {
                    VariableSymbol<int> v => new IntValueNode(v.Value),
                    VariableSymbol<StateSymbol> v => new StateValueNode(v.Value),
                    StateSymbol s => new StateValueNode(s),
                    _ => throw new ArgumentOutOfRangeException($"Unknown symbol type \"{ sym.GetType() }\""),
                });
            }
            else
                throw new Exception($"Undeclared variable { node.Label }");
        }

        private bool IsCaseMatching(CaseStatementNode c, List<ValueNode> elementValues)
        {
            // Match each value in case
            int i = 0;
            foreach (ValueNode value in c.Values)
            {

                switch (value)
                {
                    case IdentifierValueNode t:
                        Symbol sym = Stbl.st.Retrieve(t.Label);

                        if (sym != null)
                        {
                            if (!elementValues[i].Equals(sym))
                                return false;
                        }
                        else
                            throw new Exception($"Undeclared variable { t.Label }");

                        //IdentifierValueNode idNode = (IdentifierValueNode)value;
                        //if (IsState(idNode, out State state))
                        //{
                        //    if (!elementValues[i].Equals(state))
                        //        return false;
                        //}

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
