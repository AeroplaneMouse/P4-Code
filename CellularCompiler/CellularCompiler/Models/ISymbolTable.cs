using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    interface ISymbolTable
    {
        void OpenScope();

        void CloseScope();

        Symbol RetrieveSymbol(string name);

        void InsertSymbol(Symbol symbol);

        void SetAttribute();
    }
}
