using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class Scope
    {
        private List<Symbol> symbols = new List<Symbol>();

        public Symbol RetrieveSymbol(string name)
        {
            try
            {
                return symbols.Find(s => s.Name.Equals(name));
            }
            catch(ArgumentNullException)
            {
                return null;
            }
        }

        public void InsertSymbol(Symbol symbol)
        {
            if(RetrieveSymbol(symbol.Name) == null)
            {
                symbols.Add(symbol);
            }
            else
            {
                throw new Exception($"A symbol by name \"{symbol.Name}\" already exists in the symbol table!");
            }
        }


    }
}
