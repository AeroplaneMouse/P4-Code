using CellularCompiler.Exceptions;
using CellularCompiler.Models;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Evaluators
{
    class MainAstEvaluator
    {
        public Grid Visit(MainNode node)
        {
            Grid grid = Visit(node.GridNode);

            // Extract all states
            List<State> states = new List<State>();
            foreach(StatesNode s in node.StatesNodes)
                Visit(s, ref states);

            node.InitialNode;

            node.RulesNode;




            return grid;
        }

        public Grid Visit(GridNode node)
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
        public void Visit(StatesNode node, ref List<State> stateList)
        {
            List<State> states = new List<State>();

            // Generete x new states, equal to the number of labels
            // Later, its members should also be saved
            foreach(string l in node.Labels)
            {
                stateList.Add(new State());
            }
        }

    }
}
