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

        public override StatementNode VisitSelectionStatement(CoronaParser.SelectionStatementContext context)
        {
            StatementNode node = new SelectionStatementNode();


            return base.VisitSelectionStatement(context);
        }
    }
}
