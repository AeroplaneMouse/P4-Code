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
            RunningEvaluator eval = interpreter.InterpretCorona();

            //Console.WriteLine(grid);
        }

        /// <summary>
        /// Compiles corona
        /// </summary>
        /// <returns>A grid object</returns>
        private RunningEvaluator InterpretCorona()
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
            InitialEvaluator inEval = new InitialEvaluator();
            Grid grid;
            List<State> states;
            List<Rule> rules;

            inEval.Visit(ast, out grid, out states, out rules);
            
            return new RunningEvaluator(grid, states, rules);

            ////runEval.DoStuff


            //return grid;



            //GridNode gridNode = (GridNode)ast.First();
            //return new EvaluateGridVisitor().Visit(gridNode);
            throw new NotImplementedException("What ever this is going to return, has yet to be implemented");
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