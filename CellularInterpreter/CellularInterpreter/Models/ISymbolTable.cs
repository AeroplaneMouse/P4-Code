using System;
using System.Collections.Generic;
using System.Text;

namespace CI.Models
{
    interface ISymbolTable
    {
        void OpenScope();

        void CloseScope();

        Symbol Retrieve(string name);

        void Insert(Symbol symbol);
    }
}
