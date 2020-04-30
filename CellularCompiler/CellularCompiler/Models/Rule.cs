using CellularCompiler.Evaluators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class Rule
    {
        //public State State { get; set; }
        public int State { get; set; }
        public List<Statement> Statements { get; set; }

        public Rule(int state, List<Statement> statements)
        {
            State = state;
            Statements = statements;
        }

        public bool Apply(Grid grid, Cell cell)
        {
            if (cell.State == State)
            {
                StatementAstEvaluator statementEval = new StatementAstEvaluator(ref grid, cell);

                // Do statements
                foreach(Statement s in Statements)
                {
                    s.Evaluate();
                }


                return true;
            }
            else
                return false;
        }
    }
}
