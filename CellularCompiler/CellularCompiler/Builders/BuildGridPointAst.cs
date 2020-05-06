using System;
using System.Collections.Generic;
using System.Linq;
using CellularCompiler.Nodes.Math;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Builders
{
    class BuildGridPointAst : CoronaBaseVisitor<GridValueNode>
    {
        public override GridValueNode VisitGridPoint(CoronaParser.GridPointContext context)
        {
            BuildExpressionAst exprVisitor = new BuildExpressionAst();
            CoronaParser.ExprContext[] exprs = context.expr();

            if (exprs.Length != 2)
                throw new ArgumentOutOfRangeException("There must be 2 and only 2 expressions in gridPoint");

            ExpressionNode first = exprVisitor.Visit(exprs[0]);
            ExpressionNode second = exprVisitor.Visit(exprs[1]);

            return new GridValueNode(first, second);
        }

    }
}
