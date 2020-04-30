﻿using CellularCompiler.Exceptions;
using CellularCompiler.Models;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Members;
using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Evaluators
{
    class MainAstEvaluator
    {
        public Grid Visit(MainNode node)
        {
            Grid grid = VisitGrid(node.GridNode);

            // Extract all states
            List<State> states = new List<State>();
            foreach(StatesNode s in node.StatesNodes)
                VisitState(s, ref states);

            // Evaluate each statement in the initialNode, on the grid
            VisitInitial(node.InitialNode, ref grid);

            //node.RulesNode;




            return grid;
        }

        public Grid VisitGrid(GridNode node)
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
        public void VisitState(StatesNode node, ref List<State> stateList)
        {
            List<State> states = new List<State>();

            // Generete x new states, equal to the number of labels
            // TODO: Later, its members should also be saved
            foreach(string l in node.Labels)
            {
                stateList.Add(new State(l));
            }
        }

        /// <summary>
        /// Evaluates each statement in the given InitialNode and executes them on grid
        /// </summary>
        /// <param name="node"></param>
        /// <param name="grid"></param>
        public void VisitInitial(InitialNode node, ref Grid grid)
        {
            //StatementAstEvaluator statementEvaluator = new StatementAstEvaluator();
            //foreach(StatementNode s in node.Statements)
            //    statementEvaluator.Visit(s, ref grid);
        }

    }
}
