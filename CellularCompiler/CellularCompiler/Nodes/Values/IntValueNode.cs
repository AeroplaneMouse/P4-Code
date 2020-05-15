using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Values
{
    class IntValueNode : ValueNode
    {
        public int Value { get; set; }

        public IntValueNode(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is IntValueNode node)
                return Value == node.Value;
            else if (obj is int num)
                return Value == num;
            else if (obj is ArrowValueNode arrowNode)
                return Value >= arrowNode.LeftValue && Value <= arrowNode.RightValue;
            else
                return false;
        }
    }
}
