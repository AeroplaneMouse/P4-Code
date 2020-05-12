using System;
using System.Text;
using System.Collections.Generic;

namespace CellularCompiler.Models
{
    public class StateSymbol : Symbol
    {
        private static int _id = 0;
        public List<MemberSymbol> Members;

        public int ID { get; }

        public StateSymbol(string label, List<MemberSymbol> members) 
            : base(label)
        {
            ID = _id++;
            this.Members = members;
        }

        public void AddMember(MemberSymbol member)
        {
            Members.Add(member);
        }

        public MemberSymbol RetrieveMember(string label)
        {
            return Members.Find(s => s.Label.Equals(label));
        }
    }
}
