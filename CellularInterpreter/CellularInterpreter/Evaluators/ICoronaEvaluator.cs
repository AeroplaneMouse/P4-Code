using System;
using CI.Models;
using CI.Nodes.Base;
using System.Collections.Generic;

namespace CI.Evaluators
{
    public interface ICoronaEvaluator
    {
        bool ReturnStatementHasBeenHit { get; set; }
        int X_Max { get; }
        int Y_Max { get; }
        int Generation { get; }

        void Initialize();
        void PushNextGeneration();
        void GenerateNextGeneration();
        void Print();
        Cell[,] GetCurrentGeneration();
        List<StateSymbol> GetStates();

        void SetCell(Cell cell, StateSymbol state);
        Cell GetCell(int x, int y);
        Grid GetGrid();
        Cell GetCurrentCell();
    }
}