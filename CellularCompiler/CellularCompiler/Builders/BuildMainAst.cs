using System.Linq;
using System.Collections.Generic;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Statement;

namespace CellularCompiler.Builders
{
    class BuildMainAst : CoronaBaseVisitor<MainNode>
    {
        public override MainNode VisitMain(CoronaParser.MainContext context)
        {
            BuildBaseAst baseVisitor = new BuildBaseAst();

            // Visit grid
            GridNode grid = baseVisitor.Visit(context.grid()) as GridNode;

            // Visit all states
            List<StateNode> states = new List<StateNode>();
            CoronaParser.StatesContext[] statesContext = context.states();
            foreach(CoronaParser.StatesContext s in statesContext)
                states.Add(baseVisitor.Visit(s) as StateNode);

            // Visit initial
            InitialNode initial = baseVisitor.Visit(context.initial()) as InitialNode;

            // Visit rules
            //RulesNode rules = baseVisitor.Visit(context.rules()) as RulesNode;
            RulesNode rules = null;

            return new MainNode(grid, states, initial, rules);
        }
    }
}
