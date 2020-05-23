using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CI.Models
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
