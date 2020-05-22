using System;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using CellularCompiler.Models;
using CellularCompiler.Builders;
using System.Collections.Generic;
using CellularCompiler.Evaluators;
using CellularCompiler.Nodes.Base;
using System.Threading;
using CellularCompiler.ImageGeneration;
using System.Diagnostics;

namespace CellularCompiler
{
    public class CellularCompiler
    {

        private static void Main()
        {
            const int maxGenerations = 250;
            CellularCompiler interpreter = new CellularCompiler();
            ICoronaEvaluator eval = interpreter.InterpretCorona();
            ImageGenerator ig = new ImageGenerator(eval.GetGrid().XSize, eval.GetGrid().YSize);
            eval.Print();
            
            ig.GenerateFrame(eval.GetGrid());

            Console.ReadLine();
            Stopwatch total = new Stopwatch();
            Stopwatch gen = new Stopwatch();
            Stopwatch push = new Stopwatch();
            Stopwatch image = new Stopwatch();
            total.Start();
            for (int i = 2; i <= maxGenerations; i++)
            {
                //Thread.Sleep(10);
                //Console.Clear();
                gen.Start();
                eval.GenerateNextGeneration();
                gen.Stop();
                //Console.WriteLine($"Generation time:    { s.ElapsedMilliseconds } ms");

                push.Start();
                eval.PushNextGeneration();
                push.Stop();
                //Console.WriteLine($"Push time:          { s.ElapsedMilliseconds } ms");
                //Console.WriteLine($"Total elapsed time: { total.ElapsedMilliseconds / 1000 } s");
                //eval.Print();
                image.Start();
                ig.GenerateFrame(eval.GetGrid());
                image.Stop();

                if (i % 20 == 0)
                    Console.WriteLine($" Generation: { i }");
            }
            total.Stop();

            Console.WriteLine();
            Console.WriteLine($"Average gen time:   { gen.ElapsedMilliseconds / (maxGenerations - 1) } ms");
            Console.WriteLine($"Average push time:  { push.ElapsedMilliseconds / (maxGenerations - 1) } ms");
            Console.WriteLine($"Average image time: { image.ElapsedMilliseconds / (maxGenerations - 1) } ms");
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
            File.ReadAllLines("../../../../CellularCompiler/CodeExamples/CoronaTest.gjøl").ToList<string>().ForEach(s => input += s);
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