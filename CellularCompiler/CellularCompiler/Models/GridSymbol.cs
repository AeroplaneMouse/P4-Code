using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class GridSymbol : Symbol
    {
        private List<MemberSymbol> members = new List<MemberSymbol>();

        public GridSymbol(string name) : base(name)
        {

        }

        public void AddMember(MemberSymbol member)
        {
            foreach(MemberSymbol m in members)
            {
                if (m.Name.Equals(member.Name))
                    throw new Exception($"{member.Name} Already exists in the grid!");
            }

            members.Add(member);
        }
    }
}
