using System;
using System.Text;
using System.Collections.Generic;

namespace CellularCompiler.Models
{
    public class StateSymbol : Symbol
    {
        private static int _id = 0;
        private List<MemberSymbol> members;

        public int ID { get; }

        public StateSymbol(string label, List<MemberSymbol> members) 
            : base(label)
        {
            ID = _id++;
            this.members = members;
        }

        public void AddMember(MemberSymbol member)
        {
            members.Add(member);
        }

        public MemberSymbol RetrieveMember(string label)
        {
            return members.Find(s => s.Label.Equals(label));
        }
    }
}
