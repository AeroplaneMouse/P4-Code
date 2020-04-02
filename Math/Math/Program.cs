using Antlr4.Runtime;
using System;
using System.IO;

namespace Math
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.Write("> ");
                var exprText = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(exprText))
                    break;

                var inputStream = new AntlrInputStream(new StringReader(exprText));
                var lexer = new MathLexer(inputStream);
                var tokenStream = new CommonTokenStream(lexer);
                var parser = new MathParser(tokenStream);

                try
                {
                    var cst = parser.main();
                    var ast = new BuildAstVisitor().VisitMain(cst);
                    var value = new EvaluateExpressionVisitor().Visit(ast);

                    Console.WriteLine("= {0}", value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
            }
        }
    }



    internal abstract class AstVisitor<T>
    {
        public abstract T Visit(AdditionNode node);
        public abstract T Visit(NumberNode node);

        public T Visit(ExpressionNode node)
        {
            return Visit((dynamic)node);
        }
    }

    internal class EvaluateExpressionVisitor : AstVisitor<double>
    {
        public override double Visit(AdditionNode node)
        {
            return Visit(node.Left) + Visit(node.Right);
        }

        public override double Visit(NumberNode node)
        {
            return node.Value;
        }
    }
}
