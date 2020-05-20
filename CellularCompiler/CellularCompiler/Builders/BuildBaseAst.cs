using System.Collections.Generic;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Members;
using CellularCompiler.Nodes.Statement;

namespace CellularCompiler.Builders
{
    class BuildBaseAst : CoronaBaseVisitor<BaseNode>
    {
        public override BaseNode VisitGrid(CoronaParser.GridContext context)
        {
            // Create gridNode
            GridNode node = new GridNode(new List<MemberNode>());

            // Extract and visit gridnode children
            BuildMemberAst memberVisitor = new BuildMemberAst();
            foreach (CoronaParser.GridDeclarationContext d in context.gridDeclaration())
                node.Members.Add(memberVisitor.Visit(d));

            return node;
        }

        public override BaseNode VisitStates(CoronaParser.StatesContext context)
        {
            StatesNode node = new StatesNode(new List<string>(), new List<MemberNode>());

            //Get the ids for the states
            foreach(var id in context.ID())
                node.Labels.Add(id.GetText());

            // Extract and visit StateNode children
            BuildMemberAst memberVisitor = new BuildMemberAst();
            foreach (CoronaParser.MemberDeclarationContext member in context.memberDeclaration())
                node.Members.Add(memberVisitor.Visit(member));

            return node;
        }

        public override BaseNode VisitInitial(CoronaParser.InitialContext context)
        {
            // Visit each statement and add to the initial node
            StatementNode statement = new BuildStatementAst().Visit(context.compoundStatement());

            return new InitialNode(statement);
        }

        public override BaseNode VisitRules(CoronaParser.RulesContext context)
        {
            BuildStatementAst statementVisitor = new BuildStatementAst();
            RulesNode node = new RulesNode(new List<StatementNode>());

            // Visit each statement in rules
            foreach (CoronaParser.StatementContext s in context.compoundStatement().statement())
                node.Statements.Add(statementVisitor.Visit(s));

            return node;
        }
    }
}
