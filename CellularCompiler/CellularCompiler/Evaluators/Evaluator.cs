using System;
using System.Linq;
using CellularCompiler.Models;
using System.Collections.Generic;
using CellularCompiler.Exceptions;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Statement;
using CellularCompiler.Nodes.Values;
using CellularCompiler.Builders;

namespace CellularCompiler.Evaluators
{
    internal class Evaluator : ICoronaEvaluator
    {
        Grid grid { get; set; }
        List<State> states { get; set; }
        List<StatementNode> rules { get; set; }
        MainNode ast;

        public int Generation { get; private set; } = 1;

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
            rules = node.RulesNode.Statements;
            //rules = VisitRules(node.RulesNode);
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
            Generation++;
        }

        public Cell[,] GetCurrentGeneration()
        {
            return grid.GetCells() ;
        }

        public List<State> GetStates()
        {
            return states;
        }

        public void Print()
        {
            // Clear terminal
            Console.Clear();

            // Print all states
            foreach (State state in states)
                Console.WriteLine(state);

            // Print generation number
            Console.WriteLine();
            Console.WriteLine($" Generation: { Generation }");

            // Print grid
            Console.WriteLine();
            Console.WriteLine(grid);
        }

        public void SetCell(Cell cell, State state)
            => grid.SetCell(cell, state);

        public Cell GetCell(int x, int y)
            => grid.GetCell(x, y);

        private void ApplyRules(Cell cell, List<StatementNode> rules)
        {
            StatementAstEvaluator statementVisitor = new StatementAstEvaluator(this, grid, cell);
            foreach (StatementNode r in rules)
                statementVisitor.Visit(r);
        }

        private Grid VisitGrid(GridNode node)
        {
            // Just a check
            if (node.Members.Count != 2)
                throw new Exception("There must be exactly 2 axis in the grid. Otherwise, how whould it be 2D?");

            // Extract axis limits
            int x = (node.Members[0].Values[0] as IntValueNode).Value;
            int y = (node.Members[1].Values[0] as IntValueNode).Value;

            return new Grid(x, y, states.First());
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
            StatementAstEvaluator statementEvaluator = new StatementAstEvaluator(this, grid, null);
            foreach (StatementNode s in node.Statements)
                statementEvaluator.Visit(s);
        }

        /// <summary>
        /// Extracts rules..
        /// </summary>
        /// <param name="rulesNode"></param>
        /// <returns>A list of the extracted rules</returns>
        private void VisitRules(RulesNode rulesNode)
        {
            
        }
    }
}
