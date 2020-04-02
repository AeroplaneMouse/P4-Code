package com.P4;

// Generated from Calculator.G4 by ANTLR 4.8
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link CalculatorParser}.
 */
public interface CalculatorListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#main}.
	 * @param ctx the parse tree
	 */
	void enterMain(CalculatorParser.MainContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#main}.
	 * @param ctx the parse tree
	 */
	void exitMain(CalculatorParser.MainContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#expr}.
	 * @param ctx the parse tree
	 */
	void enterExpr(CalculatorParser.ExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#expr}.
	 * @param ctx the parse tree
	 */
	void exitExpr(CalculatorParser.ExprContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalculatorParser#operator}.
	 * @param ctx the parse tree
	 */
	void enterOperator(CalculatorParser.OperatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalculatorParser#operator}.
	 * @param ctx the parse tree
	 */
	void exitOperator(CalculatorParser.OperatorContext ctx);
}