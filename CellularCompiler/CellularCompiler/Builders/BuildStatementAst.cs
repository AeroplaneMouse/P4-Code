using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CellularCompiler.Nodes.Members;
using CellularCompiler.Nodes;
using System.Net.Mime;
using CellularCompiler.Models;
using System.Linq.Expressions;

namespace CellularCompiler.Builders
{
    class BuildStatementAst : CoronaBaseVisitor<StatementNode>
    {
        public override StatementNode VisitIterationStatement(CoronaParser.IterationStatementContext context)
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

        public override StatementNode VisitCompoundStatement(CoronaParser.CompoundStatementContext context)
        {
            CompoundStatementNode node = new CompoundStatementNode(new List<StatementNode>());
            
            // Visit each statement in the compound statement
            CoronaParser.StatementContext[] statements = context.statement();
            foreach (CoronaParser.StatementContext statement in statements)
                node.Statements.Add(Visit(statement));

            return node;
        }

        public override StatementNode VisitReturnStatement(CoronaParser.ReturnStatementContext context)
        {
            BuildExpressionAst exprVisitor = new BuildExpressionAst();
            ReturnStatementNode node = new ReturnStatementNode();

            //Visit expression
            node.ReturnExpression = exprVisitor.Visit(context.expr());

            return node;
        }

        public override StatementNode VisitSelectionStatement([NotNull] CoronaParser.SelectionStatementContext context)
        {
            SelectionStatementNode node = new SelectionStatementNode(new List<MemberIDNode>(), new List<CaseStatementNode>());
            // Check for state
            bool matchOnState = context.children[2].GetText() == "state";

            // Extract member identifiers
            List<MemberIDNode> memberIDNodes = ExtractMemberIDNodes(context.children);
            node.MemberIDs = memberIDNodes;

            // Extract caseStatements
            CoronaParser.CaseStatementContext[] caseStatements = context.caseStatement();

            // Visit caseStatements
            foreach (CoronaParser.CaseStatementContext value in caseStatements)
                node.CaseStatements.Add(Visit(value) as CaseStatementNode);

            return node;
        }

        public override StatementNode VisitCaseStatement([NotNull] CoronaParser.CaseStatementContext context)
        {
            BuildMemberValueAst memberValueVisitor = new BuildMemberValueAst();
            CoronaParser.MemberValueContext[] memberValues = context.memberValue();

            List<MemberValueNode> listValues = new List<MemberValueNode>();

            foreach (var value in memberValues)
            {
                listValues.Add(memberValueVisitor.Visit(value));
            }


            return new CaseStatementNode(listValues, Visit(context.statement()));
        }

        public override StatementNode VisitAssignmentStatement([NotNull] CoronaParser.AssignmentStatementContext context)
        {
            GridPointNode gridPointNode = new GridPointNode(new List<ExpressionNode>());
            MemberIDNode memberIDNode = new MemberIDNode(context.member().GetText());

            CoronaParser.GridPointContext gridPoint = context.gridPoint();
            CoronaParser.ExprContext[] expressionValues = gridPoint.expr();

            foreach (CoronaParser.ExprContext value in expressionValues)
                gridPointNode.ExpressionNodes.Add(new BuildExpressionAst().Visit(value));

            return base.VisitAssignmentStatement(context);
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

            // Extract elements
            foreach (IParseTree c in context)
            {
                // Find start and end of match values
                switch (c.GetText())
                {
                    case "(":
                        startIndex = currentIndex; break;
                    case ")":
                        endIndex = currentIndex; break;
                }
                
                // Break when end of match values has been found
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

