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