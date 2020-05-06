using CellularCompiler.Nodes.Values;
using System.Linq;

namespace CellularCompiler.Evaluators
{
    class MemberAstEvaluator
    {
        
        public int Visit(ArrowValueNode node)
            => node.RightValue;

        public int Visit(MemberNode node)
        {
            return Visit((dynamic)node.Values.First());
        }
    }
}
