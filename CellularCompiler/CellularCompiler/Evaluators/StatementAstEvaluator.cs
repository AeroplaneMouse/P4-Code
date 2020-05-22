using System;
using CellularCompiler.Models;
using System.Collections.Generic;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Values;
using CellularCompiler.Nodes.Members;
using CellularCompiler.Nodes.Statement;

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
                sender.SetCell(cell, s.Copy());
            else
                throw new Exception("Unexpected type in return statement. Must be of type STATE");

            sender.ReturnStatementHasBeenHit = true;
        }

        public void Visit(AdvancedReturnStatementNode node)
        {
            ValueAstEvaluator valueEvaluator = new ValueAstEvaluator(sender);
            MathExpressionAstEvaluator exprEvaluator = new MathExpressionAstEvaluator();
            Cell cell = sender.GetCurrentCell();
            Symbol sym = Stbl.st.Retrieve(node.Identifier.Label);

            if (sym is StateSymbol s)
            {
                // Set state members
                StateSymbol state = s.Copy();
                foreach(ReturnMemberNode rNode in node.ReturnMembers)
                {
                    MemberSymbol member = state.RetrieveMember(rNode.ID.Label);
                    switch(rNode.Value)
                    {
                        case ExpressionNode valueNode: member.SetValue(exprEvaluator.Visit(valueNode)); break;
                        case StringValueNode valueNode: member.SetValue(valueNode.Value); break;
                        default: throw new Exception($"ReturnMember value cannot be of type \'{ rNode.Value.GetType() }\'");
                    }
                }
                sender.SetCell(cell, state);
            }
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
            // Evaluate expression or string
            object result;
            if (node.Value is ExpressionNode exprNode)
            {
                if (node.Value is ComparisonNode)
                    result = new ComparisonExpressionAstEvaluator().Visit(exprNode);
                else
                    result = new MathExpressionAstEvaluator().Visit(exprNode);
            }
            else
                result = ((StringValueNode)node.Value).Value;

            // Insert into symbol table
            Symbol sym = Stbl.st.Retrieve(node.Identifier.Label);
            if (sym != null)
            {
                if (sym is VariableSymbol<int> intVar)
                    intVar.Value = (int)result;
                else if (sym is VariableSymbol<bool> boolVar)
                    boolVar.Value = (bool)result;
                else if (sym is VariableSymbol<string> stringVar)
                    stringVar.Value = (string)result;
            }
            else
            {
                switch (result)
                {
                    case int t:
                        Stbl.st.Insert(new VariableSymbol<int>(t, node.Identifier.Label));
                        break;
                    case bool t:
                        Stbl.st.Insert(new VariableSymbol<bool>(t, node.Identifier.Label));
                        break;
                    case string t:
                        Stbl.st.Insert(new VariableSymbol<string>(t, node.Identifier.Label));
                        break;
                }
            }
        }

        public void Visit(MemberAssignmentStatementNode node)
        {
            ValueAstEvaluator valueEvaluator = new ValueAstEvaluator(sender);
            Cell cell;

            // Get cell
            if (node.GridPoint != null)
                cell = valueEvaluator.Visit(node.GridPoint);
            else
                cell = sender.GetCurrentCell();

            // Evaluate expression or string
            object result;
            if (node.Value is ExpressionNode exprNode)
            {
                if (exprNode is ComparisonNode)
                    result = new ComparisonExpressionAstEvaluator().Visit(exprNode);
                else
                    result = new MathExpressionAstEvaluator().Visit(exprNode);
            }
            else
                result = ((StringValueNode)node.Value).Value;

            // Retrieve state member for the next cell
            // TODO: Check if retrieve member throw exception on not found.
            MemberSymbol member = cell.Next.State.RetrieveMember(node.MemberID.Label);

            if (member != null)
            {
                // Set new value
                switch (result)
                {
                    case int i: member.SetValue(i); break;
                    case string s: member.SetValue(s); break;
                    default: throw new Exception($"State member \'{ member.Label }\' cannot be assign value of type \'{ result.GetType() }\'");
                }
            }
            else
                throw new Exception($"Unknown state member \'{ node.MemberID.Label }\'");
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
                    case StringValueNode t:
                        values.Add(t);
                        break;
                    case IntValueNode t:
                        values.Add(t);
                        break;
                    case NumberNode t:
                        values.Add(new IntValueNode(t.Value));
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
                    VariableSymbol<string> v => new StringValueNode(v.Value),
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
                        break;

                    case IntValueNode t:
                        if (!elementValues[i].Equals(t))
                            return false;
                        break;

                    case StringValueNode t:
                        if (!elementValues[i].Equals(t))
                            return false;
                        break;

                    case ArrowValueNode t:
                        // Check if elementvalue falls inside arrow value span
                        if (elementValues[i] is IntValueNode element)
                        {
                            if (element.Value < t.LeftValue || element.Value > t.RightValue)
                                return false;
                        }
                        else
                            throw new Exception($"Cannot match arrowValue in caseStatement with element of type \'{ elementValues[i].GetType() }");
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
    } 
}
