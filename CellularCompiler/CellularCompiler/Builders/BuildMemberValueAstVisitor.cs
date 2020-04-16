using CellularCompiler.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Builders
{
    class BuildMemberValueAstVisitor : CoronaBaseVisitor<MemberValueNode>
    {
        public override MemberValueNode VisitMemberValue(CoronaParser.MemberValueContext context)
        {
            return base.VisitMemberValue(context);
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
