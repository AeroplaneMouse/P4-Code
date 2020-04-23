using System.Linq;
using System.Collections.Generic;
using CellularCompiler.Nodes.Base;

namespace CellularCompiler.Builders
{
    class BuildMainAst : CoronaBaseVisitor<MainNode>
    {
        public override MainNode VisitMain(CoronaParser.MainContext context)
        {
            BuildBaseAst visitor = new BuildBaseAst();

            // Visit grid
            GridNode grid = visitor.Visit(context.grid()) as GridNode;

            // Visit all states
            List<StateNode> states = null;
            //CoronaParser.StatesContext[] states = context.states();
            //foreach(CoronaParser.StatesContext s in states)
            //    baseNodes.Add(visitor.Visit(s));

            // Visit initial
            InitialNode initial = null;
            //baseNodes.Add(visitor.Visit(context.initial()));


            // Visit rules
            RulesNode rules = visitor.Visit(context.rules()) as RulesNode;

            return new MainNode(grid, states, initial, rules);
        }
    }
}
