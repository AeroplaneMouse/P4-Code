using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    public class State
    {
        private static int _id;

        public int ID { get; }
        public string Label { get; }
        //public List<Member> Members;

        public State(string label)
        {
            ID = _id++;
            Label = label;
        }

        public int GetLastID()
        {
            return _id - 1;
        }

        public override string ToString()
        {
            return $" [{ ID }] { Label }";
        }

        public override bool Equals(object obj)
        {
            if (obj is State b)
                return ID == b.ID;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
