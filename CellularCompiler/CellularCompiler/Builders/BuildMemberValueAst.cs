using System;
using Antlr4.Runtime.Misc;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Builders
{
    class BuildMemberValueAst : CoronaBaseVisitor<MemberValueNode>
    {
        public override MemberValueNode VisitIntMemberValue([NotNull] CoronaParser.IntMemberValueContext context)
        {
            return new IntValueNode(
                Int32.Parse(context.value.Text)
            );
        }

        public override MemberValueNode VisitStringMemberValue([NotNull] CoronaParser.StringMemberValueContext context)
        {
            return new StringValueNode(context.value.Text);
        }


        public override MemberValueNode VisitDefaultMemberValue([NotNull] CoronaParser.DefaultMemberValueContext context)
        {
            return new DefaultValueNode();
        }

        public override MemberValueNode VisitArrowValue(CoronaParser.ArrowValueContext context)
        {
            // Extract node data
            //int left = Int32.Parse(context.INT()[0].GetText());
            //int right = Int32.Parse(context.INT()[1].GetText());
            int left = 0;
            int right = Int32.Parse(context.INT().GetText());

            return new ArrowValueNode(left, right); ;
        }
    }
}
