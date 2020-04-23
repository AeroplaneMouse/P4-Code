using System.Linq;
using System.Collections.Generic;
using CellularCompiler.Nodes.Base;

namespace CellularCompiler.Builders
{
    class BuildMainAst : CoronaBaseVisitor<List<BaseNode>>
    {
        public override List<BaseNode> VisitMain(CoronaParser.MainContext context)
        {
            BuildBaseAst visitor = new BuildBaseAst();
            List<BaseNode> baseNodes = new List<BaseNode>();

            // Visit grid
            baseNodes.Add(visitor.Visit(context.grid()));

            //// Visit all states
            //CoronaParser.StatesContext[] states = context.states();
            //foreach(CoronaParser.StatesContext s in states)
            //    baseNodes.Add(visitor.Visit(s));

            //// Visit initial
            //baseNodes.Add(visitor.Visit(context.initial()));

            // Visit rules
            baseNodes.Add(visitor.Visit(context.rules()));

            return baseNodes;
        }
    }
}
