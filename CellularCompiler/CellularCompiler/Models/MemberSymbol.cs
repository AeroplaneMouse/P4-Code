using CellularCompiler.Nodes.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Models
{
    class MemberSymbol : Symbol
    {
        private object value;
        private List<MemberValueNode> acceptedValues = new List<MemberValueNode>();


        public MemberSymbol(MemberValueNode initial, List<MemberValueNode> values, string name) : base(name)
        {
            acceptedValues = values;
            value = initial;
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
