using System;
using CI.Nodes.Math;
using CI.Nodes.Values;

namespace CI.Builders
{
    class BuildValueAst : CoronaBaseVisitor<ValueNode>
    {
        public override ValueNode VisitIntValue(CoronaParser.IntValueContext context)
        {
            return new IntValueNode(
                Int32.Parse(context.INT().GetText())
            );
        }

        public override ValueNode VisitStringValue(CoronaParser.StringValueContext context)
        {
            return new StringValueNode(context.STRING().GetText());
        }

        public override ValueNode VisitIdentifierValue(CoronaParser.IdentifierValueContext context)
        {
            return new IdentifierValueNode(context.ID().GetText());
        }

        public override ValueNode VisitDefaultCaseValue(CoronaParser.DefaultCaseValueContext context)
        {
            return new DefaultValueNode();
        }

        public override ValueNode VisitArrowValue(CoronaParser.ArrowValueContext context)
        {
            // Extract node data
            int left = Int32.Parse(context.INT()[0].GetText());
            int right = Int32.Parse(context.INT()[1].GetText());

            // Range check
            if (left > right)
                throw new ArgumentOutOfRangeException("Left value must be lower or equal to the right value");

            return new ArrowValueNode(left, right);
        }

        public override ValueNode VisitGridPoint(CoronaParser.GridPointContext context)
        {
            BuildExpressionAst exprVisitor = new BuildExpressionAst();
            CoronaParser.ExprContext[] exprs = context.expr();

            if (exprs.Length != 2)
                throw new ArgumentOutOfRangeException("There must be 2 and only 2 expressions in gridPoint");

            ExpressionNode first = exprVisitor.Visit(exprs[0]);
            ExpressionNode second = exprVisitor.Visit(exprs[1]);
            IdentifierValueNode member = null;

            if (context.member() != null)
                member = new IdentifierValueNode(context.member().GetText());

            return new GridValueNode(first, second, member);
        }
    }
}
