using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class MemberSymbol : Symbol
    {
        private object value;

        private List<object> acceptedValues = new List<object>(); 
        

        public MemberSymbol(object initial, List<object> values, string name) : base(name)
        {
            acceptedValues = values;
            value = initial;
        }

        public object GetValue()
        {
            return value;
        }

        public void SetValue(object value)
        {
            if (acceptedValues.Contains(value))
                this.value = value;
            else
                throw new Exception($"Invalid value assigned to {Name}");
        }
    }
}
