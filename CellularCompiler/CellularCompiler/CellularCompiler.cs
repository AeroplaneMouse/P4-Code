﻿using System;
using System.Linq;
using System.IO;
using Antlr4.Runtime;
using System.Collections.Generic;
using CellularCompiler.Nodes;
using CellularCompiler.Visitor.Corona;
using CellularCompiler.Evaluators;
using CellularCompiler.Builders;
using CellularCompiler.Nodes.Base;
using CellularCompiler.Models;

namespace CellularCompiler
{
    internal class CellularCompiler
    {
        private static void Main()
        {
            CompileCorona();

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
            List<BaseNode> ast = new BuildBaseAstVisitor().VisitMain(cst);

            // Evaluate grid
            GridNode gridNode = (GridNode)ast.First();
            Grid grid = new EvaluateGridVisitor().Visit(gridNode);
                
            Console.WriteLine(grid);




                // Evaluate our newly compilled shitty code
                //var value = new Visitor.Corona.EvaluateMathExpressionVisitor().Visit(ast);

                //Console.WriteLine($"= { value }");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            Console.WriteLine();
        }
    }
}