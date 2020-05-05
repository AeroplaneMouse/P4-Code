using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class VariableSymbol<T> : Symbol
    {
        T value;

        public VariableSymbol(T value, string name) : base(name)
        {
            this.value = value;
        }
    }
}
