using System.Linq;
using System.Collections.Generic;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Statement;
using CellularCompiler.Models;

namespace CellularCompiler.Builders
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
            CoronaParser.StatesContext[] statesContext = context.states();
            foreach(CoronaParser.StatesContext s in statesContext)
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
