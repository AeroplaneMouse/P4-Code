using System;
using System.Text;
using System.Collections.Generic;
using CI.Nodes.Math;
using CI.Nodes.Values;
using System.Linq.Expressions;

namespace CI.Nodes.Values 
{
    class GridValueNode : ValueNode
    {
        public ExpressionNode FirstD { get; set; }
        public ExpressionNode SecondD { get; set; }
        public IdentifierValueNode Member { get; set; }

        public GridValueNode(ExpressionNode first, ExpressionNode second, IdentifierValueNode member)
        {
            FirstD = first;
            SecondD = second;
            Member = member;
        }

        public override bool Equals(object obj)
        {
            bool result;

            if (obj is GridValueNode node)
                throw new NotImplementedException();
            else
                result = false;

            return result && base.Equals(obj);
        }
    }
}
