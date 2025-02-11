﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace CI.Models
{
    public class StateSymbol : Symbol
    {
        public List<MemberSymbol> Members;

        public int ID { get; }

        public StateSymbol(string label, int id, List<MemberSymbol> members) 
            : base(label)
        {
            ID = id;
            this.Members = members;
        }

        public MemberSymbol RetrieveMember(string label)
        {
            return Members.Find(s => s.Label.Equals(label));
        }

        public StateSymbol Copy()
        {
            List<MemberSymbol> members = new List<MemberSymbol>();
            Members.ForEach(m => members.Add(m.Copy()));
            return new StateSymbol(Label, ID, members);
        }

        public override string ToString()
        {
            return $"[{ ID }] { Label }";
        }
    }
}
