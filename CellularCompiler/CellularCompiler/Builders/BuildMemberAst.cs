using System;
using CellularCompiler.Models;
using System.Collections.Generic;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Builders
{
    class BuildMemberAst : CoronaBaseVisitor<MemberNode>
    {
        public override MemberNode VisitMemberDeclaration(CoronaParser.MemberDeclarationContext context)
        {
            // Extract label
            string label = context.ID().GetText();

            //// Extract and call visit on all memberValues
            BuildValueAst memberValueVisitor = new BuildValueAst();
            List<ValueNode> valueNodes = new List<ValueNode>();
            foreach(CoronaParser.MemberValueContext value in context.memberValue())
            {
                ValueNode valueNode = memberValueVisitor.Visit(value);
                valueNodes.Add(valueNode);
            }

            Stbl.st.InsertSymbol(new MemberSymbol(valueNodes[0], valueNodes, label));

            return new MemberNode(label, valueNodes);
        }

        public override MemberNode VisitGridDeclaration(CoronaParser.GridDeclarationContext context)
        {
            // Extract label and value
            string id = context.ID().GetText();
            int value = Int32.Parse(context.INT().GetText());

            // Create valuenode and list
            IntValueNode valueNode = new IntValueNode(value);
            List<ValueNode> values = new List<ValueNode>();
            values.Add(valueNode);

            return new MemberNode(id, values);
        }
    }
}
