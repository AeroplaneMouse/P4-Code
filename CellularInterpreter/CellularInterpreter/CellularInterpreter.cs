using System;
using System.IO;
using System.Linq;
using CI.Builders;
using CI.Evaluators;
using CI.Nodes.Base;
using Antlr4.Runtime;
using CI.ImageGeneration;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;
using CellularInterpreter.Exceptions;

namespace CI
{
    public class CellularInterpreter
    {
        private static void Main()
        {
            CellularInterpreter interpreter = new CellularInterpreter();
            ICoronaEvaluator eval;
            try
            {
                eval = interpreter.InterpretCorona();
            }
            catch(CoronaLanguageException e)
            {
                string messageTree = GetExceptionMessageTree(e);
                Console.WriteLine($"You made a misstake:");
                Console.WriteLine(messageTree);
                return;
            }

            ImageGenerator ig = new ImageGenerator(eval.GetGrid().XSize, eval.GetGrid().YSize);
            eval.Print();
            
            ig.GenerateFrame(eval.GetGrid());

            // Get number of total generations
            Console.Write("Enter number of generations: ");
            if (!int.TryParse(Console.ReadLine(), out int maxGenerations))
            {
                Console.WriteLine("Invalid amount of generations");
                return;
            }

            Console.WriteLine("Generating... this might take a while");
            Stopwatch total = new Stopwatch();

            bool hit = false;
            total.Start();
            for (int i = 2; i <= maxGenerations; i++)
            {
                // Generate the next generation of cell states, but catch any error that might occur
                try
                {
                    eval.GenerateNextGeneration();
                }
                catch (CoronaLanguageException e)
                {
                    string messageTree = GetExceptionMessageTree(e);
                    Console.WriteLine($"You made a misstake");
                    Console.WriteLine(messageTree);
                    return;
                }

                // Push the next generation state to the current
                eval.PushNextGeneration();

                // Generate image representation of the new cell states
                ig.GenerateFrame(eval.GetGrid());

                // Show an estimated remaining time, when n/over of final generations has been hit
                if (IsGenerationFraction(ref hit, n:1, over: 100, eval.Generation, maxGenerations))
                {
                    Console.WriteLine($"Current generation: { eval.Generation }");
                    Console.WriteLine($"Estimated completion time in: { total.ElapsedMilliseconds / 10 } s");
                }
            }
            total.Stop();

            Console.WriteLine();
            Console.WriteLine($"Total time: { total.ElapsedMilliseconds / 1000 } s");
        }

        private static string GetExceptionMessageTree(Exception e, string padding = "")
        {
            string message = e.Message;
            
            // Add innerException
            padding += "--";
            if (e.InnerException != null)
                message+= Environment.NewLine + padding + GetExceptionMessageTree(e.InnerException, padding);

            return message;
        }

        private static bool IsGenerationFraction(ref bool hit, int n, int over, int current, int max)
        {
            // Check for hit
            if (hit)
                return false;

            // Calculate target generation
            int targetGeneration = max / (over / n);

            // Check if target generation is reached
            if(targetGeneration < 3)
                hit = true;
            else if (current % targetGeneration == 0)
            {
                hit = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compiles corona
        /// </summary>
        /// <returns>A grid object</returns>
        public ICoronaEvaluator InterpretCorona()
        {
            // Load code example
            string input = String.Empty;
            File.ReadAllLines("../../../../CellularInterpreter/CodeExamples/CoronaTest.gjøl").ToList<string>().ForEach(s => input += s);
            //File.ReadAllLines("CodeExamples/CoronaTest.gjøl").ToList<string>().ForEach(s => input += s);

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
            MainNode ast;
            try
            {
                ast = new BuildMainAst().VisitMain(cst);
            }
            catch(CoronaLanguageException e)
            {
                throw new CoronaLanguageException("Semantic error", e);
            }

            // Evaluate
            ICoronaEvaluator evaluator = new Evaluator(ast);
            evaluator.Initialize();

            return evaluator;
        }
    }
}