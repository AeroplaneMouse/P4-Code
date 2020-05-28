using System;
using System.Text;
using System.Collections.Generic;

namespace CI.Models
{
    class Scope
    {
        private List<Symbol> symbols = new List<Symbol>();

        public Symbol RetrieveSymbol(string name)
        {
            try
            {
                return symbols.Find(s => s.Label.Equals(name));
            }
            catch(ArgumentNullException)
            {
                return null;
            }
        }

        public void InsertSymbol(Symbol symbol)
        {
            if(RetrieveSymbol(symbol.Label) == null)
            {
                symbols.Add(symbol);
            }
            else
            {
                throw new Exception($"A symbol by name \"{symbol.Label}\" already exists in the symbol table!");
            }
        }
    }
}
