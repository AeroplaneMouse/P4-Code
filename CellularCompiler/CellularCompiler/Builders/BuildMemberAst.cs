using CellularCompiler.Nodes.Members;
using CellularCompiler.Builders;
using System.Collections.Generic;
using System;

namespace CellularCompiler
{
    class BuildMemberAst : CoronaBaseVisitor<MemberNode>
    {
        public override MemberNode VisitMemberDeclaration(CoronaParser.MemberDeclarationContext context)
        {
            // Extract label
            string label = context.ID().GetText();

            //// Extract and call visit on all memberValues
            BuildMemberValueAst memberValueVisitor = new BuildMemberValueAst();
            List<MemberValueNode> valueNodes = new List<MemberValueNode>();
            foreach(CoronaParser.MemberValueContext value in context.memberValue())
            {
                MemberValueNode valueNode = memberValueVisitor.Visit(value);
                valueNodes.Add(valueNode);
            }

            return new MemberNode(label, valueNodes);
        }

        public override MemberNode VisitGridDeclaration(CoronaParser.GridDeclarationContext context)
        {
            // Extract label and value
            string id = context.ID().GetText();
            int value = Int32.Parse(context.INT().GetText());

            // Create valuenode and list
            IntValueNode valueNode = new IntValueNode(value);
            List<MemberValueNode> values = new List<MemberValueNode>();
            values.Add(valueNode);

            return new MemberNode(id, values);
        }
    }
}
