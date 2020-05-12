using System;
using System.Linq;
using CellularCompiler.Models;
using System.Collections.Generic;
using CellularCompiler.Exceptions;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Values;
using CellularCompiler.Nodes.Statement;
using System.Runtime.ExceptionServices;

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
            // Create global scope
            Stbl.st.OpenScope();
            Visit(ast);
        }

        public void Visit(MainNode node)
        {
            // Create new list of states, if null
            if (states == null)
                states = new List<State>();

            // Extract all states
            StateSymbol firstState = VisitStates(node.StatesNodes);
            
            // Generate grid. Must be done after extraction of states
            grid = VisitGrid(node.GridNode, firstState);

            // Evaluate each statement in the initialNode, on the grid
            VisitInitial(node.InitialNode);
            PushNextGeneration();

            // Extract all rules
            rules = node.RulesNode.Statements;
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

        public void SetCell(Cell cell, StateSymbol state)
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
            Stbl.st.Insert(new VariableSymbol<StateSymbol>(cell.State, ".state"));

            // State member variables
            foreach(MemberSymbol member in cell.State.Members)
            {
                Stbl.st.Insert(member.GetValue() switch
                {   
                    int value => new VariableSymbol<int>(value, "." + member.Label),
                    string value => new VariableSymbol<string>(value, "." + member.Label),
                    _ => throw new Exception("Unknown cell member type"),
                });
            }

            Stbl.st.Insert(new VariableSymbol<int>(cell.Pos.X, "." + grid.AxisLabels[0]));
            Stbl.st.Insert(new VariableSymbol<int>(cell.Pos.Y, "." + grid.AxisLabels[1]));

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

        private Grid VisitGrid(GridNode node, StateSymbol firstState)
        {
            // Just a check
            if (node.Members.Count != 2)
                throw new Exception("There must be exactly 2 axis in the grid. Otherwise, how whould it be 2D?");

            // Extract axis limits
            int x = (node.Members[0].Values[0] as IntValueNode).Value;
            int y = (node.Members[1].Values[0] as IntValueNode).Value;

            // Extract axis label
            List<string> labels = new List<string>();
            foreach (MemberNode m in node.Members)
                labels.Add(m.Label);

            return new Grid(x, y, firstState, labels);
        }

        /// <summary>
        /// Extracts states from a StatesNode and creates a state foreach label in it.
        /// </summary>
        /// <param name="node">The StatesNode from which the new states should be generated from.</param>
        private StateSymbol VisitStates(List<StatesNode> nodes)
        {
            StateSymbol first = null;

            foreach(StatesNode node in nodes)
            {
                // Create states with a single label
                foreach (string label in node.Labels)
                {
                    List<MemberSymbol> members = new List<MemberSymbol>();

                    // Create member symbols
                    foreach (MemberNode m in node.Members)
                        members.Add(new MemberSymbol(m));

                    StateSymbol state = new StateSymbol(label, members);

                    // Save first
                    if (first == null)
                        first = state;

                    // Insert state into symbol table
                    Stbl.st.Insert(state);
                }
            }

            return first;
        }

        /// <summary>
        /// Evaluates each statement in the given InitialNode and executes them on grid
        /// </summary>
        /// <param name="node"></param>
        private void VisitInitial(InitialNode node)
        {
            StatementAstEvaluator statementEvaluator = new StatementAstEvaluator(this);
            statementEvaluator.Visit(node.Statement);
        }
    }
}
