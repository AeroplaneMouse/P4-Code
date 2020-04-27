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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="CoronaParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface ICoronaVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMain([NotNull] CoronaParser.MainContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.grid"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGrid([NotNull] CoronaParser.GridContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.states"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStates([NotNull] CoronaParser.StatesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.initial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInitial([NotNull] CoronaParser.InitialContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRules([NotNull] CoronaParser.RulesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.memberBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMemberBlock([NotNull] CoronaParser.MemberBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.memberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMemberDeclaration([NotNull] CoronaParser.MemberDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] CoronaParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.selectionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelectionStatement([NotNull] CoronaParser.SelectionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.iterationStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIterationStatement([NotNull] CoronaParser.IterationStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.assignmentStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentStatement([NotNull] CoronaParser.AssignmentStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompoundStatement([NotNull] CoronaParser.CompoundStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnStatement([NotNull] CoronaParser.ReturnStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.caseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCaseStatement([NotNull] CoronaParser.CaseStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>NumberExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumberExpr([NotNull] CoronaParser.NumberExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IdentifierExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExpr([NotNull] CoronaParser.IdentifierExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>InfixExpr</c>
	/// labeled alternative in <see cref="CoronaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInfixExpr([NotNull] CoronaParser.InfixExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperator([NotNull] CoronaParser.OperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.memberValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMemberValue([NotNull] CoronaParser.MemberValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.arrowValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrowValue([NotNull] CoronaParser.ArrowValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.member"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMember([NotNull] CoronaParser.MemberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CoronaParser.gridPoint"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGridPoint([NotNull] CoronaParser.GridPointContext context);
}
