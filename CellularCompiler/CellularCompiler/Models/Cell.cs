namespace CellularCompiler.Models
{
    class Cell
    {
        public int State { get; set; } = 0;

        public Cell(int state)
        {
            State = state;
        }
    }
}