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
        readonly MainNode ast;
        Cell currentCell = null;

        public int Generation { get; private set; } = 1;
        public bool ReturnStatementHasBeenHit { get; set; } = false;
        public int X_Max { get => grid.XSize; }
        public int Y_Max { get => grid.YSize; }


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
            VisitInitial(node.InitialNode);
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
                ReturnStatementHasBeenHit = false;
                currentCell = cell;
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
        {
            grid.SetCell(cell.Next, state);
        }

        public Cell GetCell(int x, int y)
        {
            return grid.GetCell(x, y);
        }

        public Cell GetCurrentCell()
        {
            return currentCell;
        }

        private void ApplyRules(Cell cell, List<StatementNode> rules)
        {
            Stbl.st.OpenScope();
            // Add cell variables
            //Stbl.st.Insert(new StateSymbol(cell.State.Label, null));
            Stbl.st.Insert(new VariableSymbol<int>(cell.Pos.X, ".x"));
            Stbl.st.Insert(new VariableSymbol<int>(cell.Pos.Y, ".y"));

            StatementAstEvaluator statementVisitor = new StatementAstEvaluator(this);
            foreach (StatementNode r in rules)
            {
                if (!ReturnStatementHasBeenHit)
                    statementVisitor.Visit(r);
                else
                    break;
            }
            Stbl.st.CloseScope();
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
        private void VisitInitial(InitialNode node)
        {
            StatementAstEvaluator statementEvaluator = new StatementAstEvaluator(this);
            statementEvaluator.Visit(node.Statement);
        }
    }
}
