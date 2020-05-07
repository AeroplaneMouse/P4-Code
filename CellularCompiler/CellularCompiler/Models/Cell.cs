using System.Dynamic;

namespace CellularCompiler.Models
{
    public class Cell
    {
        public State State { get; set; }
        public Cell Next { get; private set; }
        public Pos Pos { get; }

        public Cell(State state, Cell next, Pos pos)
        {
            State = state;
            Next = next;
            Pos = pos;
        }

        /// <summary>
        /// Returns a copy of the current cell.
        /// </summary>
        /// <returns>A copy of the current cell, with a reference to the old</returns>
        public Cell Copy()
        {
            Cell cell = new Cell(State, this, Pos.Copy());
            return cell;
        }

        public override string ToString()
        {
            return State.ID.ToString();
        }
    }
}