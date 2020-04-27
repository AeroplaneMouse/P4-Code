using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CellularCompiler.Models
{
    public class SymbolTable : ISymbolTable
    {
        private Stack<Scope> stack = new Stack<Scope>();

        public void OpenScope()
        {
            stack.Push(new Scope());
        }

        public void CloseScope()
        {
            stack.Pop();
        }

        public void InsertSymbol(Symbol symbol)
        {
            stack.Peek().InsertSymbol(symbol);
        }

        public Symbol RetrieveSymbol(string name)
        {
            Symbol symbol;

            foreach(Scope scope in stack)
            {
                symbol = scope.RetrieveSymbol(name);

                if (symbol != null)
                    return symbol;
            }

            return null;
        }

        public void SetAttribute() //Den her bliver nedern fordi der nok skal være en metode for alle type klasser vi får
        {
            throw new NotImplementedException();
        }
    }
}
