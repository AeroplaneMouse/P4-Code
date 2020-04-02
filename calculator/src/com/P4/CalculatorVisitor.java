package com.P4;

// Generated from Calculator.G4 by ANTLR 4.8
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link CalculatorParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface CalculatorVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link CalculatorParser#main}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMain(CalculatorParser.MainContext ctx);
	/**
	 * Visit a parse tree produced by {@link CalculatorParser#expr}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpr(CalculatorParser.ExprContext ctx);
	/**
	 * Visit a parse tree produced by {@link CalculatorParser#operator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOperator(CalculatorParser.OperatorContext ctx);
}