using System;
using CellularCompiler.Models;
using System.Collections.Generic;
using CellularCompiler.Exceptions;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Members;
using CellularCompiler.Nodes.Statement;

namespace CellularCompiler.Evaluators
{
    class InitialEvaluator
    {
        public void Visit(MainNode node, out Grid grid, out List<State> states, out List<Rule> rules)
        {
            grid = VisitGrid(node.GridNode);

            // Extract all states
            states = new List<State>();
            foreach (StatesNode s in node.StatesNodes)
                VisitState(s, ref states);

            // Evaluate each statement in the initialNode, on the grid
            VisitInitial(node.InitialNode, ref grid);
            grid.Push();

            //node.RulesNode;
            rules = new List<Rule>();
            //rules = VisitRules(node.RulesNode);

        }

        

        private  Grid VisitGrid(GridNode node)
        {
            // Extract the numbers of axies to create. Might be usefull later
            int axis = node.Members.Count;

            // Extract limits for each axis
            List<int> axisLimit = new List<int>();
            node.Members.ForEach((m) =>
            {
                // Extract limit from ArrowValueNode
                if (m.Values[0] is ArrowValueNode valueNode)
                    axisLimit.Add(valueNode.RightValue);
                else
                    throw new InvalidGridContentException($"Member: { m.Label } in grid, contains an invalid value. Must be a single ArrowValue");
            });

            return new Grid(axisLimit[0], axisLimit[1]);
        }

        /// <summary>
        /// Extracts states from a StatesNode and creates a state foreach label in it.
        /// </summary>
        /// <param name="node">The StatesNode from which the new states should be generated from.</param>
        /// <param name="stateList">A reference to the list, of which the extracted states should be added to.</param>
        private void VisitState(StatesNode node, ref List<State> stateList)
        {
            List<State> states = new List<State>();

            // Generete x new states, equal to the number of labels
            // TODO: Later, its members should also be saved
            foreach (string l in node.Labels)
            {
                stateList.Add(new State(l));
            }
        }

        /// <summary>
        /// Evaluates each statement in the given InitialNode and executes them on grid
        /// </summary>
        /// <param name="node"></param>
        /// <param name="grid"></param>
        private void VisitInitial(InitialNode node, ref Grid grid)
        {
            StatementAstEvaluator statementEvaluator = new StatementAstEvaluator(ref grid, null);
            foreach (StatementNode s in node.Statements)
                statementEvaluator.Visit(s);
        }

        /// <summary>
        /// Extracts rules..
        /// </summary>
        /// <param name="rulesNode"></param>
        /// <returns>A list of the extracted rules</returns>
        private List<Rule> VisitRules(RulesNode rulesNode)
        {
            throw new NotImplementedException();
        }
    }
}
