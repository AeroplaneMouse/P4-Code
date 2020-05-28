using System.Dynamic;

namespace CI.Models
{
    public class Cell
    {
        public StateSymbol State { get; set; }
        public Pos Pos { get; }

        public Cell(StateSymbol state, Pos pos)
        {
            State = state;
            Pos = pos;
        }

        /// <summary>
        /// Returns a copy of the current cell.
        /// </summary>
        /// <returns>A copy of the current cell, with a reference to the old</returns>
        public Cell Copy()
        {
            return new Cell(State.Copy(), Pos.Copy()); ;
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