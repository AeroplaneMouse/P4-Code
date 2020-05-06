using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    public class StateSymbol : Symbol
    {
        private List<MemberSymbol> members;

        public StateSymbol(string name, List<MemberSymbol> members) : base(name)
        {
            this.members = members;
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
