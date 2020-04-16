using System.Linq;
using System.Collections.Generic;
using CellularCompiler.Nodes.Base;

namespace CellularCompiler.Builders
{
    class BuildBaseAstVisitor : CoronaBaseVisitor<List<BaseNode>>
    {
        public override List<BaseNode> VisitMain(CoronaParser.MainContext context)
        {
            List<BaseNode> baseNodes = new List<BaseNode>();
            baseNodes.Add((GridNode)Visit(context.grid()).First());


            //List<CoronaParser.StatesContext> states = new List<CoronaParser.StatesContext>(context.states());
            //states.ForEach(s => Visit(s).ForEach(a => expressions.Add(a)));

            //Visit(context.initial()).ForEach(a => expressions.Add(a));
            //Visit(context.rules()).ForEach(a => expressions.Add(a));


            return baseNodes;
        }
    }
}
