using System;
using System.IO;
using System.Linq;
using CI.Builders;
using CI.Evaluators;
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
            ICoronaEvaluator eval;
            try
            {
                eval = interpreter.InterpretCorona();
            }
            catch(Exception e)
            {
                Console.WriteLine($"You made a misstake! { e.Message } ");
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
                catch (Exception e)
                {
                    Console.WriteLine($"You made a misstake! { e.Message } ");
                    return;
                }

                // Push the next generation state to the current
                eval.PushNextGeneration();

                // Generate image representation of the new cell states
                ig.GenerateFrame(eval.GetGrid());

                // Show an estimate remaining time, when 1% of final generations has been hit
                if (!hit && eval.Generation % (maxGenerations/100) == 0)
                {
                    hit = true;
                    Console.WriteLine($"Current generation: { eval.Generation }");
                    Console.WriteLine($"Estimated completion time in: { total.ElapsedMilliseconds / 10 } s");
                }
            }
            total.Stop();

            Console.WriteLine();
            Console.WriteLine($"Total time:         { total.ElapsedMilliseconds / 1000 } s");
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
            MainNode ast = new BuildMainAst().VisitMain(cst);

            // Evaluate
            ICoronaEvaluator evaluator = new Evaluator(ast);
            evaluator.Initialize();

            return evaluator;
        }
    }
}