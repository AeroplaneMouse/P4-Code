﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CI.Nodes.Values
{
    class StringValueNode : ValueNode
    {
        public string Value { get; set; }

        public StringValueNode(string value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            bool result;

            if (obj is string s)
                result = Value == s;
            else if (obj is StringValueNode sNode)
                result = Value == sNode.Value;
            else
                result = false;

            return result && base.Equals(obj);
        }
    }
}
