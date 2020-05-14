using System;
using System.Text;
using System.Windows.Markup;
using System.Collections.Generic;
using CellularCompiler.Nodes.Values;
using CellularCompiler.Nodes.Members;
using System.Linq.Expressions;

namespace CellularCompiler.Models
{
    public class MemberSymbol : Symbol
    {
        private object value;
        private List<ValueNode> acceptedValues = new List<ValueNode>();

        public MemberSymbol(MemberNode mem) 
            : this(mem.Label, mem.Values) { }

        public MemberSymbol(string label, List<ValueNode> values)
            : base(label)
        {
            acceptedValues = values;

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

        public MemberSymbol Copy()
        {
            MemberSymbol notOld = new MemberSymbol(Label, acceptedValues);
            notOld.value = value;
            return notOld;
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
            foreach(ValueNode node in acceptedValues)
            {
                if (node is IntValueNode intValue && intValue.Value == value)
                    return true;
                else if (node is ArrowValueNode arrowValue && 
                    value >= arrowValue.LeftValue && value <= arrowValue.RightValue)
                    return true;
            }

            return false;
        }

        private bool IsAccepted(string value)
        {
            foreach (ValueNode node in acceptedValues)
            {
                if (node is StringValueNode stringNode)
                    if (stringNode.Value.Equals(value))
                        return true;
            }

            return false;
        }
    }
}
