using System;
using CellularCompiler.Models;
using CellularCompiler.Nodes.Base;
using System.Collections.Generic;

namespace CellularCompiler.Evaluators
{
    interface ICoronaEvaluator
    {
        void Initialize();
        State GetStateByLabel(string label);
        void PushNextGeneration();
        void GenerateNextGeneration();
        void ApplyRules(Cell cell, List<Rule> rules);
        void Print();
    }
}