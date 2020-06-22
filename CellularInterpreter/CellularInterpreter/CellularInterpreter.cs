using System;
using System.IO;
using System.Linq;
using CI.Builders;
using CI.Evaluators;
using CI.Exceptions;
using CI.Nodes.Base;
using Antlr4.Runtime;
using CI.ImageGeneration;
using System.Diagnostics;

namespace CI
{
    public class CellularInterpreter
    {
        private static void Main()
        {
            CellularInterpreter interpreter = new CellularInterpreter();
            interpreter.EvaluateTheLanguage(1000);
        }

        private long EvaluateTheLanguage(int generations = 0)
        {
            Stopwatch total = new Stopwatch();
            total.Start();

            ICoronaEvaluator eval;
            try
            {
                eval = InterpretTheLanguage("../../../../CellularInterpreter/CodeExamples/the_language.ca");
            }
            catch (TheLanguageErrorException e)
            {
                string messageTree = GetExceptionMessageTree(e);
                Console.WriteLine($"You made a misstake:");
                Console.WriteLine(messageTree);
                return -1;
            }

            ImageGenerator ig = new ImageGenerator(eval.GetGrid().XSize, eval.GetGrid().YSize);
            ig.GenerateFrame(eval.GetGrid());

            // Get number of total generations
            if(generations == 0)
            {
                Console.Write("Enter number of generations: ");
                if (!int.TryParse(Console.ReadLine(), out generations))
                {
                    Console.WriteLine("Invalid amount of generations");
                    return -1;
                }
            }

            Console.WriteLine("Generating... this might take a while");

            bool hit = false;
            for (int i = 2; i <= generations; i++)
            {
                // Generate the next generation of cell states, but catch any error that might occur
                try
                {
                    eval.GenerateNextGeneration();
                }
                catch (TheLanguageErrorException e)
                {
                    string messageTree = GetExceptionMessageTree(e);
                    Console.WriteLine($"You made a misstake");
                    Console.WriteLine(messageTree);
                    return -1;
                }

                // Push the next generation state to the current
                eval.PushNextGeneration();

                // Generate image representation of the new cell states
                ig.GenerateFrame(eval.GetGrid());

                // Show an estimated remaining time, when n/over of final generations has been hit
                if (IsGenerationFraction(ref hit, n: 1, over: 100, eval.Generation, generations))
                {
                    Console.WriteLine($"Current generation: { eval.Generation }");
                    Console.WriteLine($"Estimated completion time in: { total.ElapsedMilliseconds / 10 - total.ElapsedMilliseconds / 1000 } s");
                }
            }
            total.Stop();

            Console.WriteLine();
            Console.WriteLine($"Total time: { total.ElapsedMilliseconds / 1000 } s");
            return total.ElapsedMilliseconds;
        }

        /// <summary>
        /// Compiles corona
        /// </summary>
        /// <returns>A grid object</returns>
        public ICoronaEvaluator InterpretTheLanguage(string path)
        {
            // Load code example
            string input = String.Empty;
            File.ReadAllLines(path).ToList<string>().ForEach(s => input += (Environment.NewLine + s));

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
            catch(TheLanguageErrorException e)
            {
                throw new TheLanguageErrorException("Semantic error", e);
            }

            // Evaluate
            ICoronaEvaluator evaluator = new Evaluator(ast);
            evaluator.Initialize();

            return evaluator;
        }

        private string GetExceptionMessageTree(Exception e, string padding = "")
        {
            string message = e.Message;

            // Add innerException
            padding += "--";
            if (e.InnerException != null)
                message += Environment.NewLine + padding + GetExceptionMessageTree(e.InnerException, padding);

            return message;
        }

        private bool IsGenerationFraction(ref bool hit, int n, int over, int current, int max)
        {
            // Check for hit
            if (hit)
                return false;

            // Calculate target generation
            int targetGeneration = max / (over / n);

            // Check if target generation is reached
            if (targetGeneration < 3)
                hit = true;
            else if (current % targetGeneration == 0)
            {
                hit = true;
                return true;
            }

            return false;
        }
    }
}