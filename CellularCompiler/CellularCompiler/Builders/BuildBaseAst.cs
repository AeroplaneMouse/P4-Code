using System.Linq;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Builders
{
    class BuildBaseAst : CoronaBaseVisitor<BaseNode>
    {
        public override BaseNode VisitGrid(CoronaParser.GridContext context)
        {
            // Create gridNode
            GridNode node = new GridNode(new List<MemberNode>());

            // Extract and visit gridnode children
            BuildMemberAst memberVisitor = new BuildMemberAst();
            List<IParseTree> memberDeclarations = context.memberBlock().children.ToList();
            foreach (IParseTree t in memberDeclarations.Skip(1).SkipLast(1))
            {
                MemberNode n = memberVisitor.Visit(t);
                node.Members.Add(n);
            }

            return node;
        }

        public override BaseNode VisitStates(CoronaParser.StatesContext context)
        {
            return base.VisitStates(context);
        }

        public override BaseNode VisitInitial(CoronaParser.InitialContext context)
        {
            return base.VisitInitial(context);
        }

        public override BaseNode VisitRules(CoronaParser.RulesContext context)
        {
            return base.VisitRules(context);
        }
    }
}
