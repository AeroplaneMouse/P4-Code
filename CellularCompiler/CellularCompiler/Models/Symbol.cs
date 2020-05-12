using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    abstract public class Symbol 
    {
        public string Label { get; set; }

        public Symbol(string name)
        {
            Label = name;
        }
    }
}
