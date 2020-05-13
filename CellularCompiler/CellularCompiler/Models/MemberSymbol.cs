using System;
using System.Text;
using System.Windows.Markup;
using System.Collections.Generic;
using CellularCompiler.Nodes.Values;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Models
{
    public class MemberSymbol : Symbol
    {
        private object value;
        private List<ValueNode> acceptedValues = new List<ValueNode>();

        public MemberSymbol(MemberNode mem) 
            : base(mem.Label)
        {
            acceptedValues = mem.Values;

            // Check if there is any values, then use the first as current
            if (acceptedValues.Count > 0)
            {
                value = acceptedValues[0] switch
                {
                    IntValueNode t => t.Value,
                    ArrowValueNode t => t.LeftValue,
                    StringValueNode t => t.Value,
                    _ => throw new ArgumentOutOfRangeException("Unknown value type")
                };
            }
        }

        public object GetValue()
        {
            return value;
        }

        public void SetValue(string value)
        {
            if (IsAccepted(value))
                this.value = value;
            else
                throw new Exception($"Invalid value assigned to {Label}");
        }

        public void SetValue(int value)
        {
            if (IsAccepted(value))
                this.value = value;
            else
                throw new Exception($"Invalid value assigned to {Label}");
        }

        private bool IsAccepted(int value)
        {
            foreach (IntValueNode i in acceptedValues)
            {
                if (i.Value == value)
                    return true;
            }

            foreach (ArrowValueNode avn in acceptedValues)
            {
                if (value >= avn.LeftValue && value <= avn.RightValue)
                    return true;
            }

            return false;
        }

        private bool IsAccepted(string value)
        {
            foreach (StringValueNode s in acceptedValues)
            {
                if (s.Value.Equals(value))
                    return true;
            }

            return false;
        }
    }
}
