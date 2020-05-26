using System;
using CellularInterpreter.Exceptions;
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

        public override ValueNode VisitMember(CoronaParser.MemberContext context)
        {
            return new IdentifierValueNode(context.GetText());
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
                throw new CoronaLanguageException($"ArrowValue { left } -> { right }: left > right");

            return new ArrowValueNode(left, right);
        }

        public override ValueNode VisitGridPoint(CoronaParser.GridPointContext context)
        {
            BuildExpressionAst exprVisitor = new BuildExpressionAst();

            // Extract the two expressions
            CoronaParser.ExprContext[] exprs = context.expr();
            ExpressionNode first = exprVisitor.Visit(exprs[0]);
            ExpressionNode second = exprVisitor.Visit(exprs[1]);

            // Extract member if present
            IdentifierValueNode member = null;
            if (context.member() != null)
                member = (IdentifierValueNode)Visit(context.member());

            return new GridValueNode(first, second, member);
        }
    }
}
