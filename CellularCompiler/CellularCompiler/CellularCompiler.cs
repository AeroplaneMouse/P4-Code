using System;
using System.Linq;
using System.IO;
using Antlr4.Runtime;
using System.Collections.Generic;

namespace CellularCompiler
{
    internal class CellularCompiler
    {
        private static void Main()
        {
            CompileMath();
        }

        private static void CompileMath()
        {
            Console.WriteLine("> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input", "Argument was null or whitespace!");

            var inputStream = new AntlrInputStream(new StringReader(input));
            var lexer = new MathLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new MathParser(tokenStream);

            try
            {
                // Extract CST from antlr's shitty files
                var cst = parser.main();
                // Build AST from CST
                var ast = new Visitor.Math.BuildMathAstVisitor().VisitMain(cst);
                // Evaluate our newly compilled shitty code
                var value = new Visitor.Math.EvaluateMathExpressionVisitor().Visit(ast);

                Console.WriteLine($"= { value }");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        private static void CompileCorona()
        {
            //string input = String.Empty;
            //File.ReadAllLines("../../../CodeExamples/CoronaTest.gjøl").ToList<string>().ForEach(s => input += s);

            //if (string.IsNullOrWhiteSpace(input))
            //    throw new ArgumentNullException();

            //var inputStream = new AntlrInputStream(new StringReader(input));
            //var lexer = new CoronaLexer(inputStream);
            //var tokenStream = new CommonTokenStream(lexer);
            //var parser = new CoronaParser(tokenStream);

            //try
            //{
            //    // Extract CTS from antlr's shitty files
            //    var cst = parser.main();
            //    // Build AST from CTS
            //    var ast = new BuildAstVisitor().VisitMain(cst);
            //    // Evaluate our newly compilled shitty code
            //    var value = new EvaluateExpressionVisitor().Visit(ast);

            //    Console.WriteLine($"= { value }");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine();
        }
    }
}