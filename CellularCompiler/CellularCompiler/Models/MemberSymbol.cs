using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class MemberSymbol<T> : Symbol
    {
        private T value;

        private List<T> acceptedValues = new List<T>(); 
        

        public MemberSymbol(T initial, List<T> values)
        {
            acceptedValues = values;
            value = initial;
        }

        public T GetValue()
        {
            return value;
        }

        public void SetValue(T value)
        {
            if (acceptedValues.Contains(value))
                this.value = value;
            else
                throw new Exception($"Invalid value assigned to {Name}");
        }
    }
}
