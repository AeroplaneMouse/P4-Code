using System;
using System.Text;
using System.Windows.Markup;
using System.Collections.Generic;
using CellularCompiler.Nodes.Values;

namespace CellularCompiler.Models
{
    public class MemberSymbol : Symbol
    {
        private object value;
        private List<ValueNode> acceptedValues = new List<ValueNode>();


        public MemberSymbol(ValueNode val) 
            : base(val.Label)
        {
            acceptedValues = val.Values;
            switch (acceptedValues[0])
            {
                case IntValueNode i:
                    value = i.Value;
                    break;
                case ArrowValueNode a:
                    value = a.LeftValue;
                    break;
                case StringValueNode s:
                    value = s.Value;
                    break;
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
                throw new Exception($"Invalid value assigned to {Name}");
        }
        public void SetValue(int value)
        {
            if (IsAccepted(value))
                this.value = value;
            else
                throw new Exception($"Invalid value assigned to {Name}");
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
