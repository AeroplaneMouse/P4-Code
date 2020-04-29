using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class StateSymbol : Symbol
    {
        private List<MemberSymbol<object>> members = new List<MemberSymbol<object>>();

        public void AddMember(MemberSymbol<object> member)
        {
            members.Add(member);
        }

        public MemberSymbol<object> RetrieveMember(string name)
        {
            return members.Find(s => s.Name.Equals(name));
        }


    }
}
