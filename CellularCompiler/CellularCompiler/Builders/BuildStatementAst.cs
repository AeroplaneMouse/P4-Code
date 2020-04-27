using Antlr4.Runtime.Misc;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Builders
{
    class BuildStatementAst : CoronaBaseVisitor<StatementNode>
    {
        public override StatementNode VisitStatement(CoronaParser.StatementContext context)
        {
            return base.Visit(context);
        }

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

            //Visit Statement
            node.ReturnStatement = Visit(context.returnstatement());

            //Visit expression
            //node.ReturnExpression = exprVisitor.Visit(context.returnexpression()); !!!ER IKKE LAVET KORREKT!!!

            return node;
        }

        public override StatementNode VisitSelectionStatement([NotNull] CoronaParser.SelectionStatementContext context)
        {
            BuildMemberAst membVisitor = new BuildMemberAst();
            SelectionStatementNode node = new SelectionStatementNode();
            CoronaParser.MemberContext[] members = context.member();
            //node = new SelectionStatementNode(new List<StatementNode>());
            //foreach (CoronaParser.MemberContext member in members)
            //{
            //    node.Members.Add(Visit(member));
            //} !!!ER IKKE LAVET KORREKT!!!


            return base.VisitSelectionStatement(context);
        }

        public override StatementNode VisitAssignmentStatement([NotNull] CoronaParser.AssignmentStatementContext context)
        {
            AssignmentStatementNode node = new AssignmentStatementNode();

            return base.VisitAssignmentStatement(context);
        }
    }
}

