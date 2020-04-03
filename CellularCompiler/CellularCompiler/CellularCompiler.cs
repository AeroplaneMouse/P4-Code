using System;
using System.IO;
using Antlr4.Runtime;
using CellularCompiler.Visitor;

namespace CellularCompiler
{
    internal class CellularCompiler
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
                    // Extract CTS from antlr's shitty files
                    var cst = parser.main();
                    // Build AST from CTS
                    var ast = new BuildAstVisitor().VisitMain(cst);
                    // Evaluate our newly compilled shitty code
                    var value = new EvaluateExpressionVisitor().Visit(ast);

                    Console.WriteLine($"= { value }");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
            }
        }
    }
}
