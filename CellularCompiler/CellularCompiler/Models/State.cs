using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class State
    {
        private static int _id;

        public int ID { get; }
        //public List<Member> Members;

        public State()
        {
            ID = _id++;
        }

        public int GetLastID()
        {
            return _id - 1;
        }
    }
}
