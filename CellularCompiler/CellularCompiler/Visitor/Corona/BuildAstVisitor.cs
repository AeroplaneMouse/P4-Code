using System;
using System.Globalization;
using CellularCompiler.Nodes;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;

namespace CellularCompiler.Visitor.Corona
{
    internal class BuildAstVisitor : CoronaBaseVisitor<List<ExpressionNode>>
    {
        public override List<ExpressionNode> VisitMain(CoronaParser.MainContext context)
        {
            List<ExpressionNode> expressions = new List<ExpressionNode>();
            GridNode grid = (GridNode)Visit(context.grid()).First();


            //List<CoronaParser.StatesContext> states = new List<CoronaParser.StatesContext>(context.states());
            //states.ForEach(s => Visit(s).ForEach(a => expressions.Add(a)));

            //Visit(context.initial()).ForEach(a => expressions.Add(a));
            //Visit(context.rules()).ForEach(a => expressions.Add(a));


            expressions.Add(grid);
            return expressions;
        }

        public override List<ExpressionNode> VisitGrid(CoronaParser.GridContext context)
        {
            // Create gridNode
            GridNode node = new GridNode(new List<MemberNode>());
            
            // Extract and visit gridnode children
            List<IParseTree> memberDeclarations = context.memberBlock().children.ToList();

            foreach(IParseTree t in memberDeclarations.Skip(1).SkipLast(1))
            {
                MemberNode n = (MemberNode)Visit(t).First();
                node.Members.Add(n);
            }

            // Return gridNode
            List<ExpressionNode> result = new List<ExpressionNode>();
            result.Add(node);
            return result;
        }

        public override List<ExpressionNode> VisitMemberDeclaration(CoronaParser.MemberDeclarationContext context)
        {
            List<ExpressionNode> result = new List<ExpressionNode>();

            string label = context.id.Text;

            string t = context.ID().GetText();

            // Extract and call visit on all memberValues
            List<ExpressionNode> expressionNodes = new List<ExpressionNode>();
            List<CoronaParser.MemberValueContext> q = new List<CoronaParser.MemberValueContext>(context.memberValue());
            q.ForEach(a => expressionNodes.AddRange(Visit(a)));

            // Convert expression nodes to membervalue nodes
            List<MemberValueNode> valueNodes = new List<MemberValueNode>();
            expressionNodes.ForEach(a => valueNodes.Add((MemberValueNode)a));


            MemberNode member = new MemberNode(label, valueNodes);
            result.Add(member);
            return result;
        }


        public override List<ExpressionNode> VisitArrowValue(CoronaParser.ArrowValueContext context)
        {
            List<ExpressionNode> result = new List<ExpressionNode>();

            // Extract node data
            int left = Int32.Parse(context.INT()[0].GetText());
            int right = Int32.Parse(context.INT()[1].GetText());

            // Create node
            ArrowValueNode node = new ArrowValueNode(left, right);

            // Return node
            result.Add(node);
            return result;
        }



        public override List<ExpressionNode> VisitInfixExpr(CoronaParser.InfixExprContext context)
        {
            // Get infix expression node type
            //InfixExpressionNode node = context.op.GetText() switch
            //{
            //    "+" => new AdditionNode(),
            //    "-" => new SubstractionNode(),
            //    "*" => new MultiplicationNode(),
            //    "/" => new DivisionNode(),
            //    _ => throw new ArgumentOutOfRangeException("context", "Unknown operator in switch statement - VisitInfixExpr")
            //};

            //// Visit the left and  of the node
            //node.Left = Visit(context.left);
            //node.Right = Visit(context.right);

            //return node;
            return new List<ExpressionNode>();
        }

        public override List<ExpressionNode> VisitStringExpr(CoronaParser.StringExprContext context)
        {
            return new List<ExpressionNode>();
            //return new StringNode(context.value.Text);
        }


        public override List<ExpressionNode> VisitNumberExpr(CoronaParser.NumberExprContext context)
        {
            return new List<ExpressionNode>();
            //return new NumberNode(
            //    double.Parse(context.value.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent)
            //);
        }
    }
}
