using System;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using CellularCompiler.Models;
using CellularCompiler.Builders;
using System.Collections.Generic;
using CellularCompiler.Evaluators;
using CellularCompiler.Nodes.Base;

namespace CellularCompiler
{
    internal class CellularCompiler
    {
        private static void Main()
        {
            CellularCompiler interpreter = new CellularCompiler();
            ICoronaEvaluator eval = interpreter.InterpretCorona();
            eval.Print();

            for(int i = 0; i < 5; i++)
            {
                eval.GenerateNextGeneration();
                eval.PushNextGeneration();    
                eval.Print();
                Console.ReadLine();
            }

            //Console.WriteLine(grid);
        }

        /// <summary>
        /// Compiles corona
        /// </summary>
        /// <returns>A grid object</returns>
        private ICoronaEvaluator InterpretCorona()
        {
            // Load code example
            string input = String.Empty;
            File.ReadAllLines("../../../CodeExamples/CoronaTest.gjøl").ToList<string>().ForEach(s => input += s);

            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input", "Argument was null or whitespace!");

            // Create token stream from input
            var inputStream = new AntlrInputStream(new StringReader(input));
            var lexer = new CoronaLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);

            // Run parser to convert token stream to CST
            var parser = new CoronaParser(tokenStream);
            var cst = parser.main();
                
            // Build AST from CST
            MainNode ast = new BuildMainAst().VisitMain(cst);

            // Evaluate
            ICoronaEvaluator evaluator = new Evaluator(ast);
            evaluator.Initialize();

            return evaluator;
        }

        /// <summary>
        /// An old example of how the math example works
        /// </summary>
        private static void CompileMath()
        {
            while (true)
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
        }
    }
}