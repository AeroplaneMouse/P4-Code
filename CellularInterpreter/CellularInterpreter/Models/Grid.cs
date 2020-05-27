using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;

namespace CI.Models
{
    public class Grid
    {
        public int XSize { get; }
        public int YSize { get; }
        public List<string> AxisLabels { get; }

        private Cell[,] Cells { get; set; }
        private Cell[,] CellsNext { get; set; }

        public Grid(int xSize, int ySize, StateSymbol firstState, List<string> axisLabels)
        {
            XSize = xSize;
            YSize = ySize;
            AxisLabels = axisLabels;
            InitializeCells(firstState);
        }

        private void InitializeCells(StateSymbol firstState)
        {
            Cells = new Cell[XSize, YSize];
            CellsNext = new Cell[XSize, YSize];

            // Initialize next
            for (int r = 0; r < XSize; r++)
                for (int c = 0; c < YSize; c++)
                    CellsNext[r, c] = new Cell(firstState.Copy(), new Pos(r, c));

            // Push the initialized cells
            Push();
        }

        public void ForAll(Action<Cell> action)
        {
            ForAll(Cells, action);
        }

        private void ForAll(Cell[,] grid, Action<Cell> action)
        {
            for (int r = 0; r < XSize; r++)
                for (int c = 0; c < YSize; c++)
                    action(grid[r, c]);
        }

        public void SetCell(int x, int y, StateSymbol state)
        {
            CellsNext[x, y].State = state;
        }

        public void SetCell(Pos pos, StateSymbol state)
        {
            CellsNext[pos.X, pos.Y].State = state;
        }

        public void SetCell(Cell cell, StateSymbol state)
        {
            cell.State = state;
        }

        public Cell GetCell(int x, int y)
        {
            return Cells[x, y];
        }

        public Cell GetCell(Pos pos)
        {
            return Cells[pos.X, pos.Y];
        }

        public Cell GetNextCell(Pos pos)
        {
            return CellsNext[pos.X, pos.Y];
        }

        public override string ToString()
        {
            string result = String.Empty;

            for (int c = 0; c < YSize; c++)
            {
                for (int r = 0; r < XSize; r++)
                {
                    result += $" { Cells[r, c] }";

                }
                result += Environment.NewLine;
            }

            return result;
        }

        public Cell[,] GetCells()
        {
            return Cells;
        }

        /// <summary>
        /// Takes a copy of every cell in CellsNext and put them into Cells
        /// </summary>
        public void Push()
        {
            for (int r = 0; r < XSize; r++)
                for (int c = 0; c < YSize; c++)
                    Cells[r, c] = CellsNext[r, c].Copy();
        }
    }
}
