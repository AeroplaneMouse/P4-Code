using CI.Nodes.Base;
using System.Collections.Generic;
using CellularInterpreter.Exceptions;

namespace CI.Builders
{
    class BuildMainAst : CoronaBaseVisitor<MainNode>
    {
        public override MainNode VisitMain(CoronaParser.MainContext context)
        {
            BuildBaseAst baseVisitor = new BuildBaseAst();

            // Visit grid
            GridNode grid;
            try
            {
                grid = (GridNode)baseVisitor.Visit(context.grid());
            }
            catch (CoronaLanguageException e) { throw new CoronaLanguageException("GRID", e); }

            // Visit all states
            List<StatesNode> states = new List<StatesNode>();
            try
            {
                foreach(CoronaParser.StatesContext s in context.states())
                    states.Add((StatesNode)baseVisitor.Visit(s));
            }
            catch (CoronaLanguageException e) { throw new CoronaLanguageException("STATES", e); }

            // Visit initial
            InitialNode initial;
            try
            {
                initial = (InitialNode)baseVisitor.Visit(context.initial());
            }
            catch (CoronaLanguageException e) { throw new CoronaLanguageException("INITIAL", e); }

            // Visit rules
            RulesNode rules;
            try
            {
                rules = (RulesNode)baseVisitor.Visit(context.rules());
            }
            catch (CoronaLanguageException e) { throw new CoronaLanguageException("RULES", e); }

            return new MainNode(grid, states, initial, rules);
        }
    }
}
