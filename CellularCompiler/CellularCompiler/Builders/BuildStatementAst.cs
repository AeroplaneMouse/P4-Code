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
            BuildStatementAst statementVisitor = new BuildStatementAst();
            IterationStatementNode node = new IterationStatementNode();

            // Visit expressions
            node.Initializer = exprVisitor.Visit(context.initializer);
            node.Conditioner = exprVisitor.Visit(context.condition);
            node.Iterator = exprVisitor.Visit(context.iterator);

            // Visit statements
            node.Statement = statementVisitor.Visit(context.statement());

            return node;
        }

        public override StatementNode VisitCompoundStatement(CoronaParser.CompoundStatementContext context)
        {
            return base.VisitCompoundStatement(context);
        }
    }
}
