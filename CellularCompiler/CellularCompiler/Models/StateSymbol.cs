using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class StateSymbol : Symbol
    {
        private List<MemberSymbol> members = new List<MemberSymbol>();

        public StateSymbol(string name) : base(name)
        {

        }

        public void AddMember(MemberSymbol member)
        {
            members.Add(member);
        }

        public MemberSymbol RetrieveMember(string name)
        {
            return members.Find(s => s.Name.Equals(name));
        }


    }
}
