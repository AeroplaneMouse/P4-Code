package com.P4;

import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.CharStreams;
import org.antlr.v4.runtime.CommonTokenStream;

import java.io.IOException;

public class Main {

    public static void main(String[] args) {
	    try {
            CharStream charStream = CharStreams.fromFileName("./Calculator-input.txt");
            CalculatorLexer lexer = new CalculatorLexer(charStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            CalculatorParser parser = new CalculatorParser(tokenStream);

            System.out.println(parser.main().toStringTree());
        }
	    catch (IOException e) {
	        System.out.println("Can't find file!");
        }
    }

}

class AdditionNode
{
	public AdditionNode Left { get; set; }
    public AdditionNode Right { get; set; }
}

class NumberNode
{
	public NumberNode Left { get; set; }
    public NumberNode Right { get; set; }
}

public class BuildAstVisitor : CalculatorVisitor<ExpressionNode>
{
    public override ExpressionNode VisitCompileUnit(MathParser.CompileUnitContext context)
    {
        return Visit(context.expr());
    }

    public override ExpressionNode VisitNumberExpr(MathParser.NumberExprContext context)
    {
        return new NumberNode
        {
            Value=double.Parse(context.value.Text,NumberStyles.AllowDecimalPoint|NumberStyles.AllowExponent)
        };
    }
}