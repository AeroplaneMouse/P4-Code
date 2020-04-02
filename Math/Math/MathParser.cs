//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Math.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class MathParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		INT=1, ADD=2, SUB=3, Whitespace=4, CR=5, NL=6, CRNL=7;
	public const int
		RULE_main = 0, RULE_expr = 1, RULE_operator = 2;
	public static readonly string[] ruleNames = {
		"main", "expr", "operator"
	};

	private static readonly string[] _LiteralNames = {
		null, null, "'+'", "'-'", null, "'\r'", "'\n'", "'\r\n'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "INT", "ADD", "SUB", "Whitespace", "CR", "NL", "CRNL"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Math.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static MathParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public MathParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public MathParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class MainContext : ParserRuleContext {
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode Eof() { return GetToken(MathParser.Eof, 0); }
		public MainContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_main; } }
		public override void EnterRule(IParseTreeListener listener) {
			IMathListener typedListener = listener as IMathListener;
			if (typedListener != null) typedListener.EnterMain(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMathListener typedListener = listener as IMathListener;
			if (typedListener != null) typedListener.ExitMain(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMathVisitor<TResult> typedVisitor = visitor as IMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMain(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MainContext main() {
		MainContext _localctx = new MainContext(Context, State);
		EnterRule(_localctx, 0, RULE_main);
		try {
			State = 10;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case INT:
				EnterOuterAlt(_localctx, 1);
				{
				State = 6; expr(0);
				State = 7; Match(Eof);
				}
				break;
			case Eof:
				EnterOuterAlt(_localctx, 2);
				{
				State = 9; Match(Eof);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
	 
		public ExprContext() { }
		public virtual void CopyFrom(ExprContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class NumberExprContext : ExprContext {
		public IToken value;
		public ITerminalNode INT() { return GetToken(MathParser.INT, 0); }
		public NumberExprContext(ExprContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IMathListener typedListener = listener as IMathListener;
			if (typedListener != null) typedListener.EnterNumberExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMathListener typedListener = listener as IMathListener;
			if (typedListener != null) typedListener.ExitNumberExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMathVisitor<TResult> typedVisitor = visitor as IMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumberExpr(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class InfixExprContext : ExprContext {
		public ExprContext Left;
		public OperatorContext op;
		public ExprContext Right;
		public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public OperatorContext @operator() {
			return GetRuleContext<OperatorContext>(0);
		}
		public InfixExprContext(ExprContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IMathListener typedListener = listener as IMathListener;
			if (typedListener != null) typedListener.EnterInfixExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMathListener typedListener = listener as IMathListener;
			if (typedListener != null) typedListener.ExitInfixExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMathVisitor<TResult> typedVisitor = visitor as IMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInfixExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		return expr(0);
	}

	private ExprContext expr(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExprContext _localctx = new ExprContext(Context, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 2;
		EnterRecursionRule(_localctx, 2, RULE_expr, _p);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			{
			_localctx = new NumberExprContext(_localctx);
			Context = _localctx;
			_prevctx = _localctx;

			State = 13; ((NumberExprContext)_localctx).value = Match(INT);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 21;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new InfixExprContext(new ExprContext(_parentctx, _parentState));
					((InfixExprContext)_localctx).Left = _prevctx;
					PushNewRecursionContext(_localctx, _startState, RULE_expr);
					State = 15;
					if (!(Precpred(Context, 2))) throw new FailedPredicateException(this, "Precpred(Context, 2)");
					State = 16; ((InfixExprContext)_localctx).op = @operator();
					State = 17; ((InfixExprContext)_localctx).Right = expr(3);
					}
					} 
				}
				State = 23;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class OperatorContext : ParserRuleContext {
		public ITerminalNode ADD() { return GetToken(MathParser.ADD, 0); }
		public ITerminalNode SUB() { return GetToken(MathParser.SUB, 0); }
		public OperatorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_operator; } }
		public override void EnterRule(IParseTreeListener listener) {
			IMathListener typedListener = listener as IMathListener;
			if (typedListener != null) typedListener.EnterOperator(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IMathListener typedListener = listener as IMathListener;
			if (typedListener != null) typedListener.ExitOperator(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMathVisitor<TResult> typedVisitor = visitor as IMathVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitOperator(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public OperatorContext @operator() {
		OperatorContext _localctx = new OperatorContext(Context, State);
		EnterRule(_localctx, 4, RULE_operator);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 24;
			_la = TokenStream.LA(1);
			if ( !(_la==ADD || _la==SUB) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 1: return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 2);
		}
		return true;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\t', '\x1D', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x2', '\x5', '\x2', '\r', '\n', '\x2', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\a', '\x3', '\x16', '\n', '\x3', '\f', '\x3', '\xE', '\x3', '\x19', 
		'\v', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x2', '\x3', '\x4', 
		'\x5', '\x2', '\x4', '\x6', '\x2', '\x3', '\x3', '\x2', '\x4', '\x5', 
		'\x2', '\x1B', '\x2', '\f', '\x3', '\x2', '\x2', '\x2', '\x4', '\xE', 
		'\x3', '\x2', '\x2', '\x2', '\x6', '\x1A', '\x3', '\x2', '\x2', '\x2', 
		'\b', '\t', '\x5', '\x4', '\x3', '\x2', '\t', '\n', '\a', '\x2', '\x2', 
		'\x3', '\n', '\r', '\x3', '\x2', '\x2', '\x2', '\v', '\r', '\a', '\x2', 
		'\x2', '\x3', '\f', '\b', '\x3', '\x2', '\x2', '\x2', '\f', '\v', '\x3', 
		'\x2', '\x2', '\x2', '\r', '\x3', '\x3', '\x2', '\x2', '\x2', '\xE', '\xF', 
		'\b', '\x3', '\x1', '\x2', '\xF', '\x10', '\a', '\x3', '\x2', '\x2', '\x10', 
		'\x17', '\x3', '\x2', '\x2', '\x2', '\x11', '\x12', '\f', '\x4', '\x2', 
		'\x2', '\x12', '\x13', '\x5', '\x6', '\x4', '\x2', '\x13', '\x14', '\x5', 
		'\x4', '\x3', '\x5', '\x14', '\x16', '\x3', '\x2', '\x2', '\x2', '\x15', 
		'\x11', '\x3', '\x2', '\x2', '\x2', '\x16', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x17', '\x15', '\x3', '\x2', '\x2', '\x2', '\x17', '\x18', '\x3', 
		'\x2', '\x2', '\x2', '\x18', '\x5', '\x3', '\x2', '\x2', '\x2', '\x19', 
		'\x17', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x1B', '\t', '\x2', '\x2', 
		'\x2', '\x1B', '\a', '\x3', '\x2', '\x2', '\x2', '\x4', '\f', '\x17',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
