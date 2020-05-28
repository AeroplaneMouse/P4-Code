using System;
using System.Collections.Generic;
using System.Text;

namespace CI.Nodes.Values
{
    class DefaultValueNode : ValueNode
    {
        public override bool Equals(object obj)
        {
            return obj is DefaultValueNode 
                && base.Equals(obj);
        }
    }
}
