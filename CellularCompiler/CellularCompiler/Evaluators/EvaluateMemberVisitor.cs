using System.Linq;
using CellularCompiler.Nodes;

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
