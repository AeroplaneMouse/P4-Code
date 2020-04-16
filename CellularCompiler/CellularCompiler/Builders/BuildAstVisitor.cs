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
            List<IParseTree> memberDeclarations = context.memberBlock().children.ToList();

            foreach (IParseTree t in memberDeclarations.Skip(1).SkipLast(1))
            {
                MemberNode n = (MemberNode)Visit(t);
                node.Members.Add(n);
            }

            // Return gridNode
            //List<ExpressionNode> result = new List<ExpressionNode>();
            //result.Add(node);
            return node;
        }
    }
}
