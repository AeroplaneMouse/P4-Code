using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CellularCompiler.Models
{
    class VariableSymbol<T> : Symbol
    {
        public T Value { get; set; }

        public VariableSymbol(T value, string name) : base(name)
        {
            Value = value;
        }
    }
}
