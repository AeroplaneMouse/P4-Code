using System;
using CellularCompiler.Models;
using System.Collections.Generic;
using CellularCompiler.Nodes.Values;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Builders
{
    class BuildMemberAst : CoronaBaseVisitor<MemberNode>
    {
        public override MemberNode VisitMemberDeclaration(CoronaParser.MemberDeclarationContext context)
        {
            BuildValueAst memberValueVisitor = new BuildValueAst();

            // Extract label
            string label = context.ID().GetText();

            // Extract and call visit on all memberValues
            List<ValueNode> valueNodes = new List<ValueNode>();
            foreach(CoronaParser.MemberValueContext member in context.memberValue())
                valueNodes.Add(memberValueVisitor.Visit(member));

            return new MemberNode(label, valueNodes);
        }

        public override MemberNode VisitGridDeclaration(CoronaParser.GridDeclarationContext context)
        {
            // Extract label and value
            string id = context.ID().GetText();
            int value = Int32.Parse(context.INT().GetText());

            // Create valuenode and list
            List<ValueNode> values = new List<ValueNode>();
            values.Add(new IntValueNode(value));

            return new MemberNode(id, values);
        }
    }
}
