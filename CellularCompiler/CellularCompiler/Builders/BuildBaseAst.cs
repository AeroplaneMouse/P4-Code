using System.Linq;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Nodes.Members;
using CellularCompiler.Nodes.Statement;
using System;
using CellularCompiler.Models;
using CellularCompiler.Exceptions;

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
            RulesNode node = new RulesNode(new List<RuleStatementNode>());

            // Extract caseStatements
            BuildStatementAst statementVisitor = new BuildStatementAst();
            CoronaParser.RuleStatementContext[] ruleStatements = context.ruleStatement();
            foreach (CoronaParser.RuleStatementContext rStatement in ruleStatements)
            {
                //// Visit each selectionStatement in rules
                //StatementNode statement = statementVisitor.Visit(s);
                //if (statement is SelectionStatementNode selection)
                //    node.Statements.Add(selection);
                //else
                //    throw new ArgumentException(nameof(statement));
                                
                //CoronaParser.CaseStatementContext[] cases = s.caseStatement();
                //foreach(CoronaParser.CaseStatementContext c in cases)
                //{
                //    StatementNode casestatement = statementVisitor.Visit(c);

                //    if (casestatement is CaseStatementNode caseNode)
                //    {
                        
                //    }
                //    else
                //        throw new ArgumentException();

                //    Rule r = new Rule(state, new List<StatementNode>());
                    
                //}
                //s.caseStatement();


                if (statementVisitor.Visit(rStatement) is RuleStatementNode sNode)
                    node.RuleStatements.Add(sNode);
                else
                    throw new InvalidRuleStatementContentException();
            }

            return node;
        }
    }
}
