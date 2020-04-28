using System;

namespace CellularCompiler.Models
{
    public class Grid
    {
        public int XSize { get; }
        public int YSize { get; }

        public int[,] Cells { get; }
        public int[,] CellsNext { get; }

        public Grid(int xSize, int ySize)
        {
            XSize = xSize;
            YSize = ySize;

            Cells = new int[XSize, YSize];
            CellsNext = new int[XSize, YSize];
        }

        private void ForAll(Action<int, int> action)
        {
            for (int r = 0; r < XSize; r++)
                for (int c = 0; c < YSize; c++)
                    action(r, c);
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

        public void Push()
        {
            ForAll((r, c) =>
            {
                Cells[r, c] = CellsNext[r, c];
            });
        }

        public virtual void ApplyRules()
        {
            // Skal overrides af kode genereret af compiler.
            // Bare et eksempel på hvordan den kan have været overridet(Conway)
            ForAll((r, c) =>
            {
                // IF DEAD
                if (Cells[r, c] == 0)
                {
                    if(Neighbors(1, r, c) == 3)
                        CellsNext[r,c] = 1;
                }
                // IF ALIVE
                if (Cells[r, c] == 1)
                {
                    if (Neighbors(1, r, c) != 3 && Neighbors(1, r, c) != 4)
                        CellsNext[r, c] = 0;
                }
            });

        }

        public int Neighbors(int state, int x, int y)
        {
            int count = 0;
            for (int r = x-1; r <= x+1; r++)
            {
                for (int c = y-1; c <= y+1; c++)
                {
                    if(!(r == x && c == y))
                    {
                        if (Cells[r, c] == state)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

    }
}
