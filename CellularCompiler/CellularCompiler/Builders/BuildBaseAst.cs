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
            CoronaParser.MemberDeclarationContext[] mDeclarations = context.memberDeclaration();
            foreach (CoronaParser.MemberDeclarationContext t in mDeclarations)
            {
                MemberNode n = memberVisitor.Visit(t);
                node.Members.Add(n);
            }

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
            List<IParseTree> memberDeclarations = context.memberBlock().children.ToList();
            foreach (IParseTree t in memberDeclarations.Skip(1).SkipLast(1))
            {
                MemberNode n = memberVisitor.Visit(t);
                node.Members.Add(n);
            }

            return node;
        }

        public override BaseNode VisitInitial(CoronaParser.InitialContext context)
        {
            InitialNode node = new InitialNode(new List<StatementNode>());

            // Extract statements
            CoronaParser.StatementContext[] statements = context.compoundStatement().statement();

            // Visit each statement and add to the initial node
            BuildStatementAst statementVisitor = new BuildStatementAst();
            foreach(CoronaParser.StatementContext s in statements)
                node.Statements.Add(statementVisitor.Visit(s));

            return node;
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
