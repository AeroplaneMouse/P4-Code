using System;
using CellularCompiler.Models;
using CellularCompiler.Nodes.Base;
using System.Collections.Generic;

namespace CellularCompiler.Evaluators
{
    public interface ICoronaEvaluator
    {
        bool ReturnStatementHasBeenHit { get; set; }
        int X_Max { get; }
        int Y_Max { get; }

        void Initialize();
        State GetStateByLabel(string label);
        void PushNextGeneration();
        void GenerateNextGeneration();
        void Print();
        Cell[,] GetCurrentGeneration();
        List<State> GetStates();

        void SetCell(Cell cell, State state);
        Cell GetCell(int x, int y);
        Cell GetCurrentCell();
    }
}