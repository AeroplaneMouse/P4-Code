using System.Dynamic;

namespace CellularCompiler.Models
{
    public class Cell
    {
        public StateSymbol State { get; set; }
        public Cell Next { get; private set; } = null;
        public Pos Pos { get; }

        public Cell(StateSymbol state, Cell next, Pos pos)
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
            Cell cell = new Cell(State.Copy(), this, Pos.Copy());
            return cell;
        }

        public override string ToString()
        {
            if (State.ID == 0)
                return " ";
            else
                return State.ID.ToString();
        }
    }
}