﻿using System.Linq;
using CellularCompiler.Nodes.Members;

namespace CellularCompiler.Evaluators
{
    class EvaluateMemberVisitor
    {
        
        public int Visit(ArrowValueNode node)
            => node.RightValue;

        public int Visit(MemberNode node)
        {
            return Visit((dynamic)node.Values.First());
        }
    }
}
