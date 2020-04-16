using System;
using CellularCompiler.Nodes;
using System.Collections.Generic;

namespace CellularCompiler
{
    class BuildMemberAstVisitor : CoronaBaseVisitor<MemberNode>
    {
        public override MemberNode VisitMemberDeclaration(CoronaParser.MemberDeclarationContext context)
        {
            // Extract label
            string label = context.ID().GetText();

            //// Extract and call visit on all memberValues
            //List<ExpressionNode> expressionNodes = new List<ExpressionNode>();
            //List<CoronaParser.MemberValueContext> q = new List<CoronaParser.MemberValueContext>(context.memberValue());
            //q.ForEach(a => expressionNodes.AddRange(Visit(a)));

            List<MemberValueNode> valueNodes = new List<MemberValueNode>();
            foreach(CoronaParser.MemberValueContext value in context.memberValue())
            {
                //valueNodes.Add(Visit(value));
                //Visit(value);
            }
            //CoronaParser.MemberValueContext[] c = context.memberValue();

            return new MemberNode(label, valueNodes);
        }

        
    }
}
