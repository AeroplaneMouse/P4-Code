using CellularCompiler.Evaluators;
using CellularCompiler.Nodes.Statement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class Rule
    {
        public List<State> States { get; set; }
        //public int State { get; set; }
        //public string StateLabel { get; set; }
        public StatementNode Statement { get; set; }

        public Rule(List<State> states, StatementNode statement)
        {
            States = states;
            Statement = statement;
        }

        //public bool Apply(ICoronaEvaluator sender, Grid grid, Cell cell)
        //{
        //    if (States.Contains(cell.State))
        //    {
        //        StatementAstEvaluator statementEval = new StatementAstEvaluator(grid, cell);

        //        // Do statements
        //        statementEval.Visit(Statement, sender);

        //        //Statement.
        //        //foreach(StatementNode s in Statements)
        //        //{
        //        //    s.Evaluate();
        //        //}
        //        return true;
        //    }
        //    else
        //        return false;
        //}
    }
}
