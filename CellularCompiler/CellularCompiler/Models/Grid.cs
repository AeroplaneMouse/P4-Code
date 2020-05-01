using System;

namespace CellularCompiler.Models
{
    class Grid
    {
        public int XSize { get; }
        public int YSize { get; }

        private Cell[,] Cells { get; set; }
        private Cell[,] CellsNext { get; set; }

        public Grid(int xSize, int ySize, State firstState)
        {
            XSize = xSize;
            YSize = ySize;
            InitializeCells(firstState);
        }

        private void InitializeCells(State firstState)
        {
            Cells = new Cell[XSize, YSize];
            CellsNext = new Cell[XSize, YSize];

            // Initialize next
            for (int r = 0; r < XSize; r++)
                for (int c = 0; c < YSize; c++)
                    CellsNext[r, c] = new Cell(firstState);
            
            // Push the initialized cells
            Push();
        }

        public void ForAll(Action<Cell> action)
        {
            ForAll(CellsNext, action);
        }

        private void ForAll(Cell[,] grid, Action<Cell> action)
        {
            for (int r = 0; r < XSize; r++)
                for (int c = 0; c < YSize; c++)
                    action(grid[r, c]);
        }

        public void SetCell(int x, int y, State state)
        {
            CellsNext[x, y].State = state;
        }

        public void SetCell(Cell cell, State state)
        {
            cell.State = state;
        }

        public Cell GetCell(int x, int y)
        {
            return CellsNext[x, y];
        }

        public override string ToString()
        {
            string result = String.Empty;

            for(int r = 0; r < XSize; r++)
            {
                for(int c = 0; c < YSize; c++)
                    result += $" { Cells[r, c] }";
                result += Environment.NewLine;
            }

            return result;
        }

        public virtual void SetInitial()
        {
            // skal overrides af kode genereret af compiler.
        }

        public void Tick()
        {
            ApplyRules();
            Push();
        }

        /// <summary>
        /// Takes a copy of every cell in CellsNext and put them into Cells
        /// </summary>
        public void Push()
        {
            for (int r = 0; r < XSize; r++)
                for (int c = 0; c < YSize; c++)
                    Cells[r, c] = CellsNext[r, c].Copy();


            //ForAll((cell) =>
            //{
            //    cell = CellsNext[r, c];
            //});
        }

        public virtual void ApplyRules()
        {
            // Skal overrides af kode genereret af compiler.
            // Bare et eksempel på hvordan den kan have været overridet(Conway)
            //ForAll((r, c) =>
            //{
            //    // IF DEAD
            //    if (Cells[r, c] == 0)
            //    {
            //        if(Neighbors(1, r, c) == 3)
            //            CellsNext[r,c] = 1;
            //    }
            //    // IF ALIVE
            //    if (Cells[r, c] == 1)
            //    {
            //        if (Neighbors(1, r, c) != 3 && Neighbors(1, r, c) != 4)
            //            CellsNext[r, c] = 0;
            //    }
            //});

        }

        public int Neighbors(int state, int x, int y)
        {
            //int count = 0;
            //for (int r = x-1; r <= x+1; r++)
            //{
            //    for (int c = y-1; c <= y+1; c++)
            //    {
            //        if(!(r == x && c == y))
            //        {
            //            if (Cells[r, c] == state)
            //            {
            //                count++;
            //            }
            //        }
            //    }
            //}
            //return count;
            throw new NotImplementedException();
        }

    }
}
