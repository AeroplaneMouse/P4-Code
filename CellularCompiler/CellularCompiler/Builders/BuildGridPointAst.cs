using System;
using CellularCompiler.Nodes;
using System.Collections.Generic;
using CellularCompiler.Nodes.Math;

namespace CellularCompiler.Builders
{
    class BuildGridPointAst : CoronaBaseVisitor<GridPointNode>
    {
        public override GridPointNode VisitGridPoint(CoronaParser.GridPointContext context)
        {
            BuildExpressionAst exprVisitor = new BuildExpressionAst();
            CoronaParser.ExprContext[] exprs = context.expr();

            List<ExpressionNode> expressions = new List<ExpressionNode>();

            // Visit each expression
            foreach (var expr in exprs)
                expressions.Add(exprVisitor.Visit(expr));

            return new GridPointNode(expressions);
        }

    }
}
