//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Grammar/Corona.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="CoronaParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface ICoronaListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMain([NotNull] CoronaParser.MainContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMain([NotNull] CoronaParser.MainContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.grid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGrid([NotNull] CoronaParser.GridContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.grid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGrid([NotNull] CoronaParser.GridContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.states"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStates([NotNull] CoronaParser.StatesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.states"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStates([NotNull] CoronaParser.StatesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.initial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInitial([NotNull] CoronaParser.InitialContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.initial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInitial([NotNull] CoronaParser.InitialContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRules([NotNull] CoronaParser.RulesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRules([NotNull] CoronaParser.RulesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.memberBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMemberBlock([NotNull] CoronaParser.MemberBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.memberBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMemberBlock([NotNull] CoronaParser.MemberBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.memberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMemberDeclaration([NotNull] CoronaParser.MemberDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.memberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMemberDeclaration([NotNull] CoronaParser.MemberDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] CoronaParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] CoronaParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.ruleStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleStatement([NotNull] CoronaParser.RuleStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.ruleStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleStatement([NotNull] CoronaParser.RuleStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.iterationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIterationStatement([NotNull] CoronaParser.IterationStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.iterationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIterationStatement([NotNull] CoronaParser.IterationStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>GridAssignStatement</c>
	/// labeled alternative in <see cref="CoronaParser.assignmentStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGridAssignStatement([NotNull] CoronaParser.GridAssignStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>GridAssignStatement</c>
	/// labeled alternative in <see cref="CoronaParser.assignmentStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGridAssignStatement([NotNull] CoronaParser.GridAssignStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>IdentifierAssignStatement</c>
	/// labeled alternative in <see cref="CoronaParser.assignmentStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierAssignStatement([NotNull] CoronaParser.IdentifierAssignStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IdentifierAssignStatement</c>
	/// labeled alternative in <see cref="CoronaParser.assignmentStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierAssignStatement([NotNull] CoronaParser.IdentifierAssignStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompoundStatement([NotNull] CoronaParser.CompoundStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompoundStatement([NotNull] CoronaParser.CompoundStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturnStatement([NotNull] CoronaParser.ReturnStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturnStatement([NotNull] CoronaParser.ReturnStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.caseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCaseStatement([NotNull] CoronaParser.CaseStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.caseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCaseStatement([NotNull] CoronaParser.CaseStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>NumberExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumberExpr([NotNull] CoronaParser.NumberExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>NumberExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumberExpr([NotNull] CoronaParser.NumberExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>ComparisonExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComparisonExpr([NotNull] CoronaParser.ComparisonExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ComparisonExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComparisonExpr([NotNull] CoronaParser.ComparisonExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>IdentifierExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierExpr([NotNull] CoronaParser.IdentifierExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IdentifierExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierExpr([NotNull] CoronaParser.IdentifierExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>InfixExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInfixExpr([NotNull] CoronaParser.InfixExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>InfixExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInfixExpr([NotNull] CoronaParser.InfixExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperator([NotNull] CoronaParser.OperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperator([NotNull] CoronaParser.OperatorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.comparisonOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComparisonOperator([NotNull] CoronaParser.ComparisonOperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.comparisonOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComparisonOperator([NotNull] CoronaParser.ComparisonOperatorContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>ArrowMemberValue</c>
	/// labeled alternative in <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrowMemberValue([NotNull] CoronaParser.ArrowMemberValueContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ArrowMemberValue</c>
	/// labeled alternative in <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrowMemberValue([NotNull] CoronaParser.ArrowMemberValueContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>IntMemberValue</c>
	/// labeled alternative in <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntMemberValue([NotNull] CoronaParser.IntMemberValueContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IntMemberValue</c>
	/// labeled alternative in <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntMemberValue([NotNull] CoronaParser.IntMemberValueContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>StringMemberValue</c>
	/// labeled alternative in <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringMemberValue([NotNull] CoronaParser.StringMemberValueContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>StringMemberValue</c>
	/// labeled alternative in <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringMemberValue([NotNull] CoronaParser.StringMemberValueContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>IdentifierMemberValue</c>
	/// labeled alternative in <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierMemberValue([NotNull] CoronaParser.IdentifierMemberValueContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IdentifierMemberValue</c>
	/// labeled alternative in <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierMemberValue([NotNull] CoronaParser.IdentifierMemberValueContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>DefaultMemberValue</c>
	/// labeled alternative in <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDefaultMemberValue([NotNull] CoronaParser.DefaultMemberValueContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>DefaultMemberValue</c>
	/// labeled alternative in <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDefaultMemberValue([NotNull] CoronaParser.DefaultMemberValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.arrowValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrowValue([NotNull] CoronaParser.ArrowValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.arrowValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrowValue([NotNull] CoronaParser.ArrowValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.member"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMember([NotNull] CoronaParser.MemberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.member"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMember([NotNull] CoronaParser.MemberContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="CoronaParser.gridPoint"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGridPoint([NotNull] CoronaParser.GridPointContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="CoronaParser.gridPoint"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGridPoint([NotNull] CoronaParser.GridPointContext context);
}
