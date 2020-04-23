using System.Linq;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Members;
using CellularCompiler.Nodes.Statement;
using System;

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
            List<IParseTree> memberDeclarations = context.memberBlock().children.ToList();
            foreach (IParseTree t in memberDeclarations.Skip(1).SkipLast(1))
            {
                MemberNode n = memberVisitor.Visit(t);
                node.Members.Add(n);
            }

            return node;
        }

        public override BaseNode VisitStates(CoronaParser.StatesContext context)
        {
            return base.VisitStates(context);
        }

        public override BaseNode VisitInitial(CoronaParser.InitialContext context)
        {
            return base.VisitInitial(context);
        }

        public override BaseNode VisitRules(CoronaParser.RulesContext context)
        {
            RulesNode node = new RulesNode(new List<SelectionStatementNode>());

            // Extract selectionStatements
            BuildStatementAst statementVisitor = new BuildStatementAst();
            CoronaParser.SelectionStatementContext[] selections = context.selectionStatement();
            foreach (CoronaParser.SelectionStatementContext s in selections)
            {
                // Visit each selectionStatement in rules
                StatementNode statement = statementVisitor.Visit(s);
                if (statement is SelectionStatementNode selection)
                    node.Statements.Add(selection);
                else
                    throw new ArgumentException(nameof(statement));
            }

            return node;
        }
    }
}
