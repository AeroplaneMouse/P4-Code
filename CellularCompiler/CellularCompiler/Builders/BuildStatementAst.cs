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
            // Check for state
            bool matchOnState = context.children[2].GetText() == "state";

            // Extract member identifiers
            List<MemberIDNode> memberIDNodes = ExtractMemberIDNodes(context.children);

            // Extract and visit caseStatements
            List<CaseStatementNode> caseNodes = new List<CaseStatementNode>();
            CoronaParser.CaseStatementContext[] caseStatements = context.caseStatement();
            foreach (CoronaParser.CaseStatementContext cs in caseStatements)
                caseNodes.Add(Visit(cs) as CaseStatementNode);

            return new SelectionStatementNode(matchOnState, memberIDNodes, caseNodes);
        }

        public override StatementNode VisitCaseStatement([NotNull] CoronaParser.CaseStatementContext context)
        {
            BuildMemberValueAst memberValueVisitor = new BuildMemberValueAst();
            CoronaParser.MemberValueContext[] memberValues = context.memberValue();
            
            List<MemberValueNode> listValues = new List<MemberValueNode>();
            
            // Visit each memberValue and add it to the CaseStatementNode
            foreach (var value in memberValues)
                listValues.Add(memberValueVisitor.Visit(value));


            return new CaseStatementNode(listValues, Visit(context.statement()));
        }

        public override StatementNode VisitAssignmentStatement(CoronaParser.AssignmentStatementContext context)
        {
            BuildExpressionAst expressionVisitor = new BuildExpressionAst();
            GridPointNode gridPointNode = new GridPointNode(new List<ExpressionNode>());
            MemberIDNode memberIDNode = null;
            if (context.member() != null)
                memberIDNode = new MemberIDNode(context.member().GetText());
             
            // Extract gridPoint and visit it's expressions
            CoronaParser.MathExprContext[] exprValues = context.gridPoint().mathExpr();
            foreach (CoronaParser.MathExprContext expr in exprValues)
                gridPointNode.ExpressionNodes.Add(expressionVisitor.Visit(expr));

            // Visit expression
            if (context.expr() != null)
                return new AssignmentStatementNode(
                    gridPointNode,
                    memberIDNode,
                    expressionVisitor.Visit(context.expr()));

            // Visit string
            else if (context.STRING() != null)
                return new AssignmentStatementNode(
                    gridPointNode,
                    memberIDNode,
                    context.STRING().GetText());
            else
                throw new ArgumentNullException();
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

