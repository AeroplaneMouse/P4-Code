using System;
using System.Linq;
using System.Net.Mime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CellularCompiler.Nodes;
using System.Collections.Generic;
using CellularCompiler.Exceptions;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Statement;
using CellularCompiler.Nodes.Values;
using System.Diagnostics.Tracing;

namespace CellularCompiler.Builders
{
    class BuildStatementAst : CoronaBaseVisitor<StatementNode>
    {
        public override StatementNode VisitIterationStatement([NotNull] CoronaParser.IterationStatementContext context)
        {
            BuildExpressionAst exprVisitor = new BuildExpressionAst();
            IterationStatementNode node = new IterationStatementNode();

            // Visit expressions
            node.Initializer = exprVisitor.Visit(context.initializer);
            node.Conditioner = exprVisitor.Visit(context.condition);
            node.Iterator = exprVisitor.Visit(context.iterator);

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
            if (new BuildValueAst().Visit(context) is IdentifierValueNode node)
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
            //BuildValueAst valueVisitor = new BuildValueAst();
            //BuildExpressionAst exprVisitor = new BuildExpressionAst();
            //List<CaseStatementNode> caseStatements = new List<CaseStatementNode>();

            //// Visit each match element
            //List<ValueNode> matchElements = new List<ValueNode>();
            //CoronaParser.MatchElementContext[] elements = context.matchElement();
            //foreach (var element in elements)
            //{
            //    if (element.GetText() == ".state")
            //        matchElements.Add(new IdentifierValueNode(".state"));
            //    else if(element.gridPoint() != null)
            //    {


            //        ExpressionNode expr1 = exprVisitor.Visit();

            //        matchElements.Add(GridPointNode);

            //    }
            //    else if(element.expr() != null)
            //    {
            //        exprVisitor.Visit(element.expr());
            //        matchElements.Add();
            //    }


            //    valueVisitor.Visit(element);

            //}

            //// Visit each CaseStatement
            //CoronaParser.CaseStatementContext[] cases = context.caseStatement();
            //foreach (CoronaParser.CaseStatementContext c in cases)
            //{
            //    if (Visit(c) is CaseStatementNode caseNode)
            //        caseStatements.Add(caseNode);
            //    else
            //        throw new InvalidMatchStatementContentException();
            //}                

            //return new MatchStatementNode(caseStatements);
            throw new NotImplementedException();
        }

        public override StatementNode VisitGridAssignStatement([NotNull] CoronaParser.GridAssignStatementContext context)
        {
            BuildExpressionAst expressionVisitor = new BuildExpressionAst();
            BuildGridPointAst gridpointVisitor = new BuildGridPointAst();

            string idLabel = context.ID().GetText();
            
            // Extract memberID, if it is used
            MemberIDNode memberIDNode = null;
            if (context.member() != null)
                memberIDNode = new MemberIDNode(context.member().GetText());

            // Visit GridPoint
            GridPointNode gridpoint = gridpointVisitor.Visit(context.gridPoint());

            return new GridAssignmentStatementNode(gridpoint, memberIDNode, idLabel);
        }

        public override StatementNode VisitIdentifierAssignStatement([NotNull] CoronaParser.IdentifierAssignStatementContext context)
        {
            return base.VisitIdentifierAssignStatement(context);
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

