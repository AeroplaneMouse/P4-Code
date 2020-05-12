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
            CoronaParser.StatementContext[] statements = context.statement();
            foreach (CoronaParser.StatementContext statement in statements)
                node.Statements.Add(Visit(statement));

            return node;
        }

        public override StatementNode VisitReturnStatement([NotNull] CoronaParser.ReturnStatementContext context)
        {
            if (new BuildValueAst().Visit(context.identifierValue()) is IdentifierValueNode node)
                return new ReturnStatementNode(node);
            else
                throw new Exception("ReturnStatement does not contain an identifier");
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

            CoronaParser.MatchElementContext[] matchElements = context.matchElement();
            List<ValueNode> elements = new List<ValueNode>();

            // Visit each of the different elements to match against
            foreach (var e in matchElements)
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
            CoronaParser.CaseStatementContext[] cases = context.caseStatement();
            foreach (CoronaParser.CaseStatementContext c in cases)
                caseStatements.Add(Visit(c) as CaseStatementNode);

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
            IdentifierValueNode memberID = new IdentifierValueNode("." + context.identifierValue().GetText());

            // Get expression
            ExpressionNode expr = exprVisitor.Visit(context.expr());

            return new MemberAssignmentStatementNode(gridPoint, memberID, expr);
        }

        /// <summary>
        /// Extracts MemberIDNodes from matchStatement context
        /// </summary>
        /// <param name="context">Children of context</param>
        /// <returns>A list of MemberIDNodes</returns>
        private List<MemberIDNode> ExtractMemberIDNodes(IList<IParseTree> context)
        {
            int startIndex = -1;
            int endIndex = -1;
            int currentIndex = 0;

            // Find start and end
            foreach (IParseTree c in context)
            {
                switch (c.GetText())
                {
                    case "(":
                        startIndex = currentIndex; break;
                    case ")":
                        endIndex = currentIndex; break;
                }
                
                // Break, when the end of match values has been found
                if (endIndex == currentIndex)
                    break;
                currentIndex++;
            }

            // Construct nodes
            List<MemberIDNode> nodes = new List<MemberIDNode>();
            for(currentIndex = startIndex + 1; currentIndex < endIndex; currentIndex++)
            {
                string label = context[currentIndex].GetText();
                if (label == "state")
                    continue;
                else
                    nodes.Add(new MemberIDNode(label));
            }

            return nodes;
        }
    }
}

