using System;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Builders
{
    class BuildMemberValueAst : CoronaBaseVisitor<MemberValueNode>
    {
        public override MemberValueNode VisitIntMemberValue(CoronaParser.IntMemberValueContext context)
        {
            return new IntValueNode(
                Int32.Parse(context.value.Text)
            );
        }

        public override MemberValueNode VisitStringMemberValue(CoronaParser.StringMemberValueContext context)
        {
            return new StringValueNode(context.value.Text);
        }

        public override MemberValueNode VisitIdentifierCaseValue(CoronaParser.IdentifierCaseValueContext context)
        {
            return new IdentifierValueNode(context.ID().GetText());
        }

        public override MemberValueNode VisitDefaultCaseValue(CoronaParser.DefaultCaseValueContext context)
        {
            return new DefaultValueNode();
        }

        public override MemberValueNode VisitArrowValue(CoronaParser.ArrowValueContext context)
        {
            // Extract node data
            int left = Int32.Parse(context.INT()[0].GetText());
            int right = Int32.Parse(context.INT()[1].GetText());

            return new ArrowValueNode(left, right); ;
        }
    }
}
