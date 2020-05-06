using System.Dynamic;

namespace CellularCompiler.Models
{
    public class Cell
    {
        public State State { get; set; }
        public Cell Next { get; private set; }

        public Cell(State state)
        {
            State = state;
            Next = null;
        }

        /// <summary>
        /// Returns a copy of the current cell.
        /// </summary>
        /// <returns>A copy of the current cell, with a reference to the old</returns>
        public Cell Copy()
        {
            Cell cell = new Cell(State);
            cell.Next = this;
            return cell;
        }

        public override string ToString()
        {
            return State.ID.ToString();
        }
    }
}