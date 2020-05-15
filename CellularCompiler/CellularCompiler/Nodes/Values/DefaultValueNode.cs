using System;
using System.Collections.Generic;
using System.Text;

namespace CellularCompiler.Nodes.Values
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
