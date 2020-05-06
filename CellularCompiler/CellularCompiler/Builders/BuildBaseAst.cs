using System;
using System.Linq;
using Antlr4.Runtime.Tree;
using CellularCompiler.Models;
using System.Collections.Generic;
using CellularCompiler.Exceptions;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Statement;
using CellularCompiler.Nodes.Values;

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
            CoronaParser.GridDeclarationContext[] gDeclarations = context.gridDeclaration();
            foreach (CoronaParser.GridDeclarationContext t in gDeclarations)
                node.Members.Add(memberVisitor.Visit(t));

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
            CoronaParser.MemberDeclarationContext[] memberDeclarations = context.memberDeclaration();
            foreach (CoronaParser.MemberDeclarationContext member in memberDeclarations)
            {
                MemberNode n = memberVisitor.Visit(member);
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
            BuildStatementAst statementVisitor = new BuildStatementAst();
            RulesNode node = new RulesNode(new List<StatementNode>());

            // Visit each statement in rules
            CoronaParser.StatementContext[] statements = context.compoundStatement().statement();
            foreach (var s in statements)
                node.Statements.Add(statementVisitor.Visit(s));

            return node;
        }
    }
}
