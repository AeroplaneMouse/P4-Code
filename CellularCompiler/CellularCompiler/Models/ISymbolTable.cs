using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    interface ISymbolTable
    {
        void OpenScope();

        void CloseScope();

        Symbol Retrieve(string name);

        void Insert(Symbol symbol);
    }
}
