namespace CellularCompiler.Models
{
    public class Cell
    {
        public State State { get; set; }

        public Cell(State state)
        {
            State = state;
        }

        /// <summary>
        /// Returns a copy of the current cell.
        /// </summary>
        /// <returns>A copy of the current cell</returns>
        public Cell Copy()
        {
            Cell cell = new Cell(State);
            return cell;
        }

        public override string ToString()
        {
            return State.ID.ToString();
        }
    }
}