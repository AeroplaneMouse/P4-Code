using Antlr4.Runtime.Tree;
using CellularCompiler.Nodes;
using CellularCompiler.Nodes.Base;
using System.Collections.Generic;
using System.Linq;

namespace CellularCompiler.Builders
{
    class BuildAstVisitor : CoronaBaseVisitor<BaseNode>
    {
        public override BaseNode VisitGrid(CoronaParser.GridContext context)
        {
            // Create gridNode
            GridNode node = new GridNode(new List<MemberNode>());

            // Extract and visit gridnode children
            BuildMemberAstVisitor memberVisitor = new BuildMemberAstVisitor();
            List<IParseTree> memberDeclarations = context.memberBlock().children.ToList();
            foreach (IParseTree t in memberDeclarations.Skip(1).SkipLast(1))
            {
                MemberNode n = memberVisitor.Visit(t);
                node.Members.Add(n);
            }

            return node;
        }
    }
}
