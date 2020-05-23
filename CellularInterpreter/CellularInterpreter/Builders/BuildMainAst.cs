using System.Linq;
using System.Collections.Generic;
using CI.Nodes.Base;
using CI.Nodes.Statement;
using CI.Models;

namespace CI.Builders
{
    class BuildMainAst : CoronaBaseVisitor<MainNode>
    {
        public override MainNode VisitMain(CoronaParser.MainContext context)
        {
            BuildBaseAst baseVisitor = new BuildBaseAst();

            // Visit grid
            GridNode grid = (GridNode)baseVisitor.Visit(context.grid());

            // Visit all states
            List<StatesNode> states = new List<StatesNode>();
            foreach(CoronaParser.StatesContext s in context.states())
                states.Add((StatesNode)baseVisitor.Visit(s));

            // Visit initial
            InitialNode initial = (InitialNode)baseVisitor.Visit(context.initial());

            // Visit rules
            RulesNode rules = (RulesNode)baseVisitor.Visit(context.rules());

            //Add to SymTab

            return new MainNode(grid, states, initial, rules);
        }
    }
}
