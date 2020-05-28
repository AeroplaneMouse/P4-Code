using CI.Nodes.Base;
using System.Collections.Generic;
using CI.Exceptions;

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
            catch (TheLanguageErrorException e) { throw new TheLanguageErrorException("GRID", e); }

            // Visit all states
            List<StatesNode> states = new List<StatesNode>();
            try
            {
                foreach(CoronaParser.StatesContext s in context.states())
                    states.Add((StatesNode)baseVisitor.Visit(s));
            }
            catch (TheLanguageErrorException e) { throw new TheLanguageErrorException("STATES", e); }

            // Visit initial
            InitialNode initial;
            try
            {
                initial = (InitialNode)baseVisitor.Visit(context.initial());
            }
            catch (TheLanguageErrorException e) { throw new TheLanguageErrorException("INITIAL", e); }

            // Visit rules
            RulesNode rules;
            try
            {
                rules = (RulesNode)baseVisitor.Visit(context.rules());
            }
            catch (TheLanguageErrorException e) { throw new TheLanguageErrorException("RULES", e); }

            return new MainNode(grid, states, initial, rules);
        }
    }
}
