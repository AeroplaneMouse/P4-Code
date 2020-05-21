using System;
using System.Linq;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CellularCompiler.Nodes;
using System.Collections.Generic;
using CellularCompiler.Exceptions;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Statement;
using CellularCompiler.Nodes.Values;
using CellularCompiler.Evaluators;
using System.Linq.Expressions;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Builders
{
    class BuildStatementAst : CoronaBaseVisitor<StatementNode>
    {
        public override StatementNode VisitIterationStatement([NotNull] CoronaParser.IterationStatementContext context)
        {
            BuildExpressionAst exprVisitor = new BuildExpressionAst();
            IterationStatementNode node = new IterationStatementNode();

            // Visit expressions
            node.Conditioner = exprVisitor.Visit(context.conditioner);

            // Visit statement
            node.Statement = Visit(context.statement());

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
            IdentifierValueNode id = (IdentifierValueNode)new BuildValueAst().Visit(context.identifierValue());

            return new ReturnStatementNode(id);
        }

        public override StatementNode VisitAdvancedReturn([NotNull] CoronaParser.AdvancedReturnContext context)
        {
            BuildValueAst valueVisitor = new BuildValueAst();

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

        public override StatementNode VisitCaseStatement([NotNull] CoronaParser.CaseStatementContext context)
        {
            BuildValueAst valueVisitor = new BuildValueAst();
            CoronaParser.CaseValueContext[] caseValues = context.caseValue();

            // Extract all caseValues
            List<ValueNode> values = new List<ValueNode>();
            foreach (var value in caseValues)
                values.Add(valueVisitor.Visit(value));

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
                if (e.member() != null)
                    elements.Add(new IdentifierValueNode(e.member().GetText()));

                else if (e.gridPoint() != null)
                    elements.Add(valueVisitor.Visit(e.gridPoint()));
                
                else if (e.expr() != null)
                    elements.Add(exprVisitor.Visit(e.expr()));
            }

            // Visit each CaseStatement
            List<CaseStatementNode> caseStatements = new List<CaseStatementNode>();
            foreach (CoronaParser.CaseStatementContext c in context.caseStatement())
                caseStatements.Add((CaseStatementNode)Visit(c));

            return new MatchStatementNode(elements, caseStatements);
        }

        public override StatementNode VisitGridAssignStatement([NotNull] CoronaParser.GridAssignStatementContext context)
        {
            BuildValueAst valueVisitor= new BuildValueAst();

            IdentifierValueNode id = new IdentifierValueNode(context.ID().GetText());
            GridValueNode gridpoint = (GridValueNode) valueVisitor.Visit(context.gridPoint());

            return new GridAssignmentStatementNode(gridpoint, id);
        }

        public override StatementNode VisitIdentifierAssignStatement([NotNull] CoronaParser.IdentifierAssignStatementContext context)
        {
            BuildValueAst valueVisitor = new BuildValueAst();
            BuildExpressionAst exprVisitor = new BuildExpressionAst();

            IdentifierValueNode id = valueVisitor.Visit(context.identifierValue()) as IdentifierValueNode;
            ExpressionNode expr = exprVisitor.Visit(context.expr());

            return new IdentifierAssignmentStatementNode(id, expr);
        }

        public override StatementNode VisitMemberAssignStatement([NotNull] CoronaParser.MemberAssignStatementContext context)
        {
            BuildValueAst valueVisitor = new BuildValueAst();
            BuildExpressionAst exprVisitor = new BuildExpressionAst();

            // Get GridPoint
            GridValueNode gridPoint = null;
            if (context.gridPoint() != null)
                gridPoint = (GridValueNode)valueVisitor.Visit(context.gridPoint());

            // Get Member 
            IdentifierValueNode memberID = new IdentifierValueNode(context.identifierValue().GetText());

            // Get expression
            ExpressionNode expr = exprVisitor.Visit(context.expr());

            return new MemberAssignmentStatementNode(gridPoint, memberID, expr);
        }
    }
}

