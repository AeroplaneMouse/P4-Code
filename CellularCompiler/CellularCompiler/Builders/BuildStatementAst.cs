using Antlr4.Runtime.Misc;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
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

        public override StatementNode VisitAssignmentStatement([NotNull] CoronaParser.AssignmentStatementContext context)
        {
            AssignmentStatementNode node = new AssignmentStatementNode();

            return base.VisitAssignmentStatement(context);
        }
    }
}

