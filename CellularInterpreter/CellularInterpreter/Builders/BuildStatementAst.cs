using Antlr4.Runtime.Misc;
using System.Collections.Generic;
using CI.Nodes.Statement;
using CI.Nodes.Values;
using CI.Nodes.Members;
using CI.Exceptions;

namespace CI.Builders
{
    class BuildStatementAst : CoronaBaseVisitor<StatementNode>
    {
        public override StatementNode VisitIterationStatement([NotNull] CoronaParser.IterationStatementContext context)
        {
            BuildExpressionAst exprVisitor = new BuildExpressionAst();
            IterationStatementNode node = new IterationStatementNode();

            try
            {
                // Visit expressions
                node.Conditioner = exprVisitor.Visit(context.conditioner);

                // Visit statement
                node.Statement = Visit(context.statement());
            }
            catch(TheLanguageErrorException e) { throw new TheLanguageErrorException("Iteration statement", e); }

            return node;
        }

        public override StatementNode VisitCompoundStatement([NotNull] CoronaParser.CompoundStatementContext context)
        {
            CompoundStatementNode node = new CompoundStatementNode(new List<StatementNode>());
            
            // Visit each statement in the compound statement
            foreach (CoronaParser.StatementContext statement in context.statement())
                node.Statements.Add(Visit(statement));

            return node;
        }

        public override StatementNode VisitSimpleReturn([NotNull] CoronaParser.SimpleReturnContext context)
        {
            IdentifierValueNode id;
            try
            {
                id = (IdentifierValueNode)new BuildValueAst().Visit(context.identifierValue());
            }
            catch (TheLanguageErrorException e) { throw new TheLanguageErrorException("Return statement", e); }

            return new ReturnStatementNode(id);
        }

        public override StatementNode VisitAdvancedReturn([NotNull] CoronaParser.AdvancedReturnContext context)
        {
            BuildValueAst valueVisitor = new BuildValueAst();

            try
            {
                IdentifierValueNode id = (IdentifierValueNode)valueVisitor.Visit(context.identifierValue());

                // Get returnMembers
                List<ReturnMemberNode> returnMembers = new List<ReturnMemberNode>();
                foreach(var rMember in context.returnMember())
                {
                    // Get ReturnMember value
                    ValueNode value;
                    if (rMember.expr() != null)
                        value = new BuildExpressionAst().Visit(rMember.expr());
                    else
                        value = new StringValueNode(rMember.STRING().GetText());

                    // Add new ReturnMember to list
                    returnMembers.Add(new ReturnMemberNode(
                        (IdentifierValueNode)valueVisitor.Visit(rMember.identifierValue()),
                        value)
                    );
                }

                return new AdvancedReturnStatementNode(id, returnMembers);
            }
            catch(TheLanguageErrorException e) { throw new TheLanguageErrorException("Return statement", e); }
        }

        public override StatementNode VisitCaseStatement([NotNull] CoronaParser.CaseStatementContext context)
        {
            BuildValueAst valueVisitor = new BuildValueAst();
            CoronaParser.CaseValueContext[] caseValues = context.caseValue();

            // Extract all caseValues
            List<ValueNode> values = new List<ValueNode>();
            try
            {
                foreach (var value in caseValues)
                    values.Add(valueVisitor.Visit(value));
            }
            catch(TheLanguageErrorException e) { throw new TheLanguageErrorException("Case statement value", e); }

            return new CaseStatementNode(values, Visit(context.statement()));
        }

        public override StatementNode VisitMatchStatement([NotNull] CoronaParser.MatchStatementContext context)
        {
            BuildValueAst valueVisitor = new BuildValueAst();
            BuildExpressionAst exprVisitor = new BuildExpressionAst();
            
            // Visit each of the different elements to match against
            List<ValueNode> elements = new List<ValueNode>();
            foreach (var e in context.matchElement())
            {
                try
                {
                    if (e.member() != null)
                        elements.Add(valueVisitor.Visit(e.member()));

                    else if (e.gridPoint() != null)
                        elements.Add(valueVisitor.Visit(e.gridPoint()));

                    else if (e.expr() != null)
                        elements.Add(exprVisitor.Visit(e.expr()));
                }
                catch (TheLanguageErrorException excep) { throw new TheLanguageErrorException("Match statement value", excep); }
            }

            // Visit each CaseStatement
            List<CaseStatementNode> caseStatements = new List<CaseStatementNode>();
            try
            {
                foreach (CoronaParser.CaseStatementContext c in context.caseStatement())
                    caseStatements.Add((CaseStatementNode)Visit(c));
            }
            catch (TheLanguageErrorException e) { throw new TheLanguageErrorException("Match statement", e); }

            return new MatchStatementNode(elements, caseStatements);
        }

        public override StatementNode VisitGridAssignStatement([NotNull] CoronaParser.GridAssignStatementContext context)
        {
            BuildValueAst valueVisitor= new BuildValueAst();

            try
            {
                IdentifierValueNode id = new IdentifierValueNode(context.ID().GetText());
                GridValueNode gridpoint = (GridValueNode) valueVisitor.Visit(context.gridPoint());

                return new GridAssignmentStatementNode(gridpoint, id);
            }
            catch (TheLanguageErrorException e) { throw new TheLanguageErrorException("Grid assignment statement", e); }
        }

        public override StatementNode VisitIdentifierAssignStatement([NotNull] CoronaParser.IdentifierAssignStatementContext context)
        {
            BuildValueAst valueVisitor = new BuildValueAst();
            BuildExpressionAst exprVisitor = new BuildExpressionAst();
            
            try
            {
                IdentifierValueNode id = valueVisitor.Visit(context.identifierValue()) as IdentifierValueNode;

                // Get value
                ValueNode value;
                if (context.expr() != null)
                    value = exprVisitor.Visit(context.expr());
                else
                    value = new StringValueNode(context.STRING().GetText());

                return new IdentifierAssignmentStatementNode(id, value);
            }
            catch (TheLanguageErrorException e) { throw new TheLanguageErrorException("Identifier assignment statement", e); }
        }

        public override StatementNode VisitMemberAssignStatement([NotNull] CoronaParser.MemberAssignStatementContext context)
        {
            BuildValueAst valueVisitor = new BuildValueAst();
            BuildExpressionAst exprVisitor = new BuildExpressionAst();
            try
            {
                // Get GridPoint
                GridValueNode gridPoint = null;
                if (context.gridPoint() != null)
                    gridPoint = (GridValueNode)valueVisitor.Visit(context.gridPoint());

                // Get Member 
                IdentifierValueNode memberID = new IdentifierValueNode(context.identifierValue().GetText());

                // Get value
                ValueNode value;
                if (context.expr() != null)
                    value = exprVisitor.Visit(context.expr());
                else
                    value = new StringValueNode(context.STRING().GetText());

                return new MemberAssignmentStatementNode(gridPoint, memberID, value);
            }
            catch (TheLanguageErrorException e) { throw new TheLanguageErrorException("Member assignment statement", e); }

        }
    }
}

