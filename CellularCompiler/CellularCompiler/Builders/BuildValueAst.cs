using System;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Builders
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

            return new ArrowValueNode(left, right);
        }
    }
}
