using System;
using CellularCompiler.Models;
using CellularCompiler.Nodes.Base;
using System.Collections.Generic;

namespace CellularCompiler.Evaluators
{
    public interface ICoronaEvaluator
    {
        void Initialize();
        State GetStateByLabel(string label);
        void PushNextGeneration();
        void GenerateNextGeneration();
        void Print();
        Cell[,] GetCurrentGeneration();
        List<State> GetStates();
    }
}