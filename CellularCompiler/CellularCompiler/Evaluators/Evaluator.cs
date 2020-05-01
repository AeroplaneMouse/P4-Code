using System;
using CellularCompiler.Models;
using System.Collections.Generic;
using CellularCompiler.Exceptions;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Members;
using CellularCompiler.Nodes.Statement;
using System.Linq;

namespace CellularCompiler.Evaluators
{
    class Evaluator : ICoronaEvaluator
    {
        Grid grid { get; set; }
        List<State> states { get; set; }
        List<Rule> rules { get; set; }
        MainNode ast;

        public Evaluator(MainNode ast)
        {
            this.ast = ast;
        }

        public void Initialize()
        {
            Visit(ast);
        }

        public void Visit(MainNode node)
        {
            // Create new list of states, if null
            if (states == null)
                states = new List<State>();

            // Extract all states
            foreach (StatesNode s in node.StatesNodes)
                states.AddRange(VisitState(s));
            
            // Generate grid. Must be done after extraction of states
            grid = VisitGrid(node.GridNode);

            // Evaluate each statement in the initialNode, on the grid
            VisitInitial(node.InitialNode, grid);
            PushNextGeneration();

            // Extract all rules
            rules = VisitRules(node.RulesNode);
        }

        public State GetStateByLabel(string label)
        {
            foreach (State s in states)
            {
                if (s.Label == label)
                    return s;
            }

            throw new UnknownStateLabelException($"No State with label \'{ label }\' exists in the evaluator");
        }

        public void PushNextGeneration()
        {
            grid.Push();
        }

        public void GenerateNextGeneration()
        {
            grid.ForAll((cell) =>
            {
                ApplyRules(cell, rules);
            });
        }

        public void ApplyRules(Cell cell, List<Rule> rules)
        {
            foreach (Rule r in rules)
                if (r.Apply(this, grid, cell))
                    break;
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine(grid);
        }


        private Grid VisitGrid(GridNode node)
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

            return new Grid(axisLimit[0], axisLimit[1], states.First());
        }

        /// <summary>
        /// Extracts states from a StatesNode and creates a state foreach label in it.
        /// </summary>
        /// <param name="node">The StatesNode from which the new states should be generated from.</param>
        /// <param name="stateList">A reference to the list, of which the extracted states should be added to.</param>
        private List<State> VisitState(StatesNode node)
        {
            List<State> states = new List<State>();

            // Generete x new states, equal to the number of labels
            // TODO: Later, its members should also be saved
            foreach (string l in node.Labels)
            {
                states.Add(new State(l));
            }

            return states;
        }

        /// <summary>
        /// Evaluates each statement in the given InitialNode and executes them on grid
        /// </summary>
        /// <param name="node"></param>
        /// <param name="grid"></param>
        private void VisitInitial(InitialNode node, Grid grid)
        {
            StatementAstEvaluator statementEvaluator = new StatementAstEvaluator(grid, null);
            foreach (StatementNode s in node.Statements)
                statementEvaluator.Visit(s, this);
        }

        /// <summary>
        /// Extracts rules..
        /// </summary>
        /// <param name="rulesNode"></param>
        /// <returns>A list of the extracted rules</returns>
        private List<Rule> VisitRules(RulesNode rulesNode)
        {
            List<Rule> rules = new List<Rule>();

            StatementAstEvaluator statementEvaluator = new StatementAstEvaluator(null, null);
            foreach (RuleStatementNode rsNode in rulesNode.RuleStatements)
                rules.AddRange(statementEvaluator.VisitRuleStatementNode(rsNode, this));

            return rules;
        }
    }
}
