using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CellularCompiler.Nodes.Members;

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

            // Extract member identifiers

            // Visit member identifiers

            // Extract caseStatements

            // Visit caseStatements

            // Return SelectionStatementNode(matchOnState, memberIdentifiers, caseStatements)
            


            bool macthOnState = context.children[2].GetText() == "state";

            foreach(var c in context.children)
            {
                Console.WriteLine(c);
            }

            foreach(var value in context.caseStatement())
            {
                
            }
            BuildMemberAst membVisitor = new BuildMemberAst();
            SelectionStatementNode node = new SelectionStatementNode();
            CoronaParser.MemberContext[] members = context.member();
            node = new SelectionStatementNode(new List<StatementNode>());
            foreach (CoronaParser.MemberContext member in members)
            {
                node.Members.Add(Visit(member));
            }

            //context.children[0].GetText == "state";

            return base.VisitSelectionStatement(context);
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

        private List<MemberIdNode> ExtractMemberIdNodes(IParseTree[] context)
        {
            int startIndex = 0;
            int endIndex = 0;
            int currentIndex = 0;

            // Extract elements
            foreach (IParseTree c in context)
            {
                if (c.GetText() == "(")
                    startIndex = currentIndex;
                else if (c.GetText() == ")")
                    endIndex = currentIndex;

                currentIndex++;
            }

            // Construct nodes
            List<MemberIdNode> nodes = null;

            return nodes;
        }

        public override StatementNode VisitAssignmentStatement([NotNull] CoronaParser.AssignmentStatementContext context)
        {
            AssignmentStatementNode node = new AssignmentStatementNode();

            return base.VisitAssignmentStatement(context);
        }
    }
}

