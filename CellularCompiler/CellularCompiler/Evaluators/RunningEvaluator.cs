using CellularCompiler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Evaluators
{
    class RunningEvaluator
    {
        Grid grid { get; set; }
        List<State> states { get; set; }
        List<Rule> rules { get; set; }

        public RunningEvaluator(Grid grid, List<State> states, List<Rule> rules)
        {
            this.grid = grid;
            this.states = states;
            this.rules = rules;
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
                if (r.Apply(grid, cell))
                    break;
        }

        public void PushNextGeneration()
        {
            grid.Push();
        }
    }
}
