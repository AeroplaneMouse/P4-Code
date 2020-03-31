// Generated from c:\Users\Trung Nhan Tran\Repos\P4-Code\Antlr\P4.G4 by ANTLR 4.7.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class P4Parser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, Int=12, Float=13, Identifier=14, Less=15, Greater=16, 
		LessEqual=17, GreaterEqual=18, Equal=19, NotEqual=20, Plus=21, Minus=22, 
		Mult=23, Div=24, Mod=25, Power=26, LParen=27, RParen=28, LCurly=29, RCurly=30, 
		Void=31, Whitespace=32, CR=33, NL=34, CRNL=35;
	public static final int
		RULE_program = 0, RULE_initialSetup = 1, RULE_setup = 2, RULE_settings = 3, 
		RULE_statelist = 4, RULE_function = 5, RULE_statement = 6, RULE_assignment = 7, 
		RULE_statlist = 8, RULE_ruledefinition = 9, RULE_ifstatement = 10, RULE_forstatement = 11, 
		RULE_whilestatement = 12, RULE_setstatement = 13, RULE_setter = 14, RULE_decl = 15, 
		RULE_expr = 16, RULE_operator = 17, RULE_operand = 18, RULE_functiondefinition = 19, 
		RULE_typeparameterlist = 20, RULE_functioncall = 21, RULE_paralist = 22, 
		RULE_parameter = 23, RULE_keywords = 24, RULE_type = 25;
	public static final String[] ruleNames = {
		"program", "initialSetup", "setup", "settings", "statelist", "function", 
		"statement", "assignment", "statlist", "ruledefinition", "ifstatement", 
		"forstatement", "whilestatement", "setstatement", "setter", "decl", "expr", 
		"operator", "operand", "functiondefinition", "typeparameterlist", "functioncall", 
		"paralist", "parameter", "keywords", "type"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'grid:'", "','", "'states:'", "';'", "'='", "'RULE'", "'if'", "'for'", 
		"'while'", "'set'", "'int'", null, null, null, "'<'", "'>'", "'<='", "'>='", 
		"'=='", "'!='", "'+'", "'-'", "'*'", "'/'", "'%'", "'^'", "'('", "')'", 
		"'{'", "'}'", "'void'", null, "'\r'", "'\n'", "'\r\n'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		"Int", "Float", "Identifier", "Less", "Greater", "LessEqual", "GreaterEqual", 
		"Equal", "NotEqual", "Plus", "Minus", "Mult", "Div", "Mod", "Power", "LParen", 
		"RParen", "LCurly", "RCurly", "Void", "Whitespace", "CR", "NL", "CRNL"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "P4.G4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public P4Parser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class ProgramContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(P4Parser.EOF, 0); }
		public InitialSetupContext initialSetup() {
			return getRuleContext(InitialSetupContext.class,0);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(53);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << T__5) | (1L << T__10) | (1L << Int) | (1L << Void))) != 0)) {
				{
				setState(52);
				initialSetup(0);
				}
			}

			setState(55);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class InitialSetupContext extends ParserRuleContext {
		public SetupContext setup() {
			return getRuleContext(SetupContext.class,0);
		}
		public InitialSetupContext initialSetup() {
			return getRuleContext(InitialSetupContext.class,0);
		}
		public InitialSetupContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_initialSetup; }
	}

	public final InitialSetupContext initialSetup() throws RecognitionException {
		return initialSetup(0);
	}

	private InitialSetupContext initialSetup(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		InitialSetupContext _localctx = new InitialSetupContext(_ctx, _parentState);
		InitialSetupContext _prevctx = _localctx;
		int _startState = 2;
		enterRecursionRule(_localctx, 2, RULE_initialSetup, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(58);
			setup();
			}
			_ctx.stop = _input.LT(-1);
			setState(64);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,1,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new InitialSetupContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_initialSetup);
					setState(60);
					if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
					setState(61);
					setup();
					}
					} 
				}
				setState(66);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,1,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class SetupContext extends ParserRuleContext {
		public SettingsContext settings() {
			return getRuleContext(SettingsContext.class,0);
		}
		public FunctiondefinitionContext functiondefinition() {
			return getRuleContext(FunctiondefinitionContext.class,0);
		}
		public FunctionContext function() {
			return getRuleContext(FunctionContext.class,0);
		}
		public RuledefinitionContext ruledefinition() {
			return getRuleContext(RuledefinitionContext.class,0);
		}
		public DeclContext decl() {
			return getRuleContext(DeclContext.class,0);
		}
		public SetupContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_setup; }
	}

	public final SetupContext setup() throws RecognitionException {
		SetupContext _localctx = new SetupContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_setup);
		try {
			setState(72);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(67);
				settings();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(68);
				functiondefinition();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(69);
				function();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(70);
				ruledefinition();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(71);
				decl();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SettingsContext extends ParserRuleContext {
		public List<TerminalNode> Int() { return getTokens(P4Parser.Int); }
		public TerminalNode Int(int i) {
			return getToken(P4Parser.Int, i);
		}
		public StatelistContext statelist() {
			return getRuleContext(StatelistContext.class,0);
		}
		public SettingsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_settings; }
	}

	public final SettingsContext settings() throws RecognitionException {
		SettingsContext _localctx = new SettingsContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_settings);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(74);
			match(T__0);
			setState(75);
			match(Int);
			setState(76);
			match(T__1);
			setState(77);
			match(Int);
			setState(78);
			match(T__2);
			setState(79);
			statelist();
			setState(80);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatelistContext extends ParserRuleContext {
		public TerminalNode Identifier() { return getToken(P4Parser.Identifier, 0); }
		public StatelistContext statelist() {
			return getRuleContext(StatelistContext.class,0);
		}
		public StatelistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statelist; }
	}

	public final StatelistContext statelist() throws RecognitionException {
		StatelistContext _localctx = new StatelistContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_statelist);
		try {
			setState(86);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(82);
				match(Identifier);
				setState(83);
				match(T__1);
				setState(84);
				statelist();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(85);
				match(Identifier);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionContext extends ParserRuleContext {
		public FunctiondefinitionContext functiondefinition() {
			return getRuleContext(FunctiondefinitionContext.class,0);
		}
		public FunctionContext function() {
			return getRuleContext(FunctionContext.class,0);
		}
		public FunctionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_function; }
	}

	public final FunctionContext function() throws RecognitionException {
		FunctionContext _localctx = new FunctionContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_function);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(88);
			functiondefinition();
			setState(89);
			function();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementContext extends ParserRuleContext {
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public IfstatementContext ifstatement() {
			return getRuleContext(IfstatementContext.class,0);
		}
		public ForstatementContext forstatement() {
			return getRuleContext(ForstatementContext.class,0);
		}
		public SetstatementContext setstatement() {
			return getRuleContext(SetstatementContext.class,0);
		}
		public WhilestatementContext whilestatement() {
			return getRuleContext(WhilestatementContext.class,0);
		}
		public FunctioncallContext functioncall() {
			return getRuleContext(FunctioncallContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_statement);
		try {
			setState(97);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(91);
				assignment();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(92);
				ifstatement();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(93);
				forstatement();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(94);
				setstatement();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(95);
				whilestatement();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(96);
				functioncall();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentContext extends ParserRuleContext {
		public TerminalNode Identifier() { return getToken(P4Parser.Identifier, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode Int() { return getToken(P4Parser.Int, 0); }
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_assignment);
		try {
			setState(105);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,5,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(99);
				match(Identifier);
				setState(100);
				match(T__4);
				setState(101);
				expr(0);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(102);
				match(Identifier);
				setState(103);
				match(T__4);
				setState(104);
				match(Int);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatlistContext extends ParserRuleContext {
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public StatlistContext statlist() {
			return getRuleContext(StatlistContext.class,0);
		}
		public StatlistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statlist; }
	}

	public final StatlistContext statlist() throws RecognitionException {
		StatlistContext _localctx = new StatlistContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_statlist);
		try {
			setState(111);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__6:
			case T__7:
			case T__8:
			case T__9:
			case Identifier:
				enterOuterAlt(_localctx, 1);
				{
				setState(107);
				statement();
				setState(108);
				statlist();
				}
				break;
			case RCurly:
				enterOuterAlt(_localctx, 2);
				{
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class RuledefinitionContext extends ParserRuleContext {
		public TerminalNode Identifier() { return getToken(P4Parser.Identifier, 0); }
		public TerminalNode LCurly() { return getToken(P4Parser.LCurly, 0); }
		public StatlistContext statlist() {
			return getRuleContext(StatlistContext.class,0);
		}
		public TerminalNode RCurly() { return getToken(P4Parser.RCurly, 0); }
		public RuledefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ruledefinition; }
	}

	public final RuledefinitionContext ruledefinition() throws RecognitionException {
		RuledefinitionContext _localctx = new RuledefinitionContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_ruledefinition);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(113);
			match(T__5);
			setState(114);
			match(Identifier);
			setState(115);
			match(LCurly);
			setState(116);
			statlist();
			setState(117);
			match(RCurly);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IfstatementContext extends ParserRuleContext {
		public TerminalNode LParen() { return getToken(P4Parser.LParen, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode RParen() { return getToken(P4Parser.RParen, 0); }
		public TerminalNode LCurly() { return getToken(P4Parser.LCurly, 0); }
		public StatlistContext statlist() {
			return getRuleContext(StatlistContext.class,0);
		}
		public TerminalNode RCurly() { return getToken(P4Parser.RCurly, 0); }
		public IfstatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifstatement; }
	}

	public final IfstatementContext ifstatement() throws RecognitionException {
		IfstatementContext _localctx = new IfstatementContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_ifstatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(119);
			match(T__6);
			setState(120);
			match(LParen);
			setState(121);
			expr(0);
			setState(122);
			match(RParen);
			setState(123);
			match(LCurly);
			setState(124);
			statlist();
			setState(125);
			match(RCurly);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ForstatementContext extends ParserRuleContext {
		public TerminalNode LParen() { return getToken(P4Parser.LParen, 0); }
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public TerminalNode RParen() { return getToken(P4Parser.RParen, 0); }
		public TerminalNode LCurly() { return getToken(P4Parser.LCurly, 0); }
		public StatlistContext statlist() {
			return getRuleContext(StatlistContext.class,0);
		}
		public TerminalNode RCurly() { return getToken(P4Parser.RCurly, 0); }
		public ForstatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_forstatement; }
	}

	public final ForstatementContext forstatement() throws RecognitionException {
		ForstatementContext _localctx = new ForstatementContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_forstatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(127);
			match(T__7);
			setState(128);
			match(LParen);
			setState(129);
			assignment();
			setState(130);
			match(T__3);
			setState(131);
			expr(0);
			setState(132);
			match(T__3);
			setState(133);
			statement();
			setState(134);
			match(RParen);
			setState(135);
			match(LCurly);
			setState(136);
			statlist();
			setState(137);
			match(RCurly);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class WhilestatementContext extends ParserRuleContext {
		public TerminalNode LParen() { return getToken(P4Parser.LParen, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode RParen() { return getToken(P4Parser.RParen, 0); }
		public TerminalNode LCurly() { return getToken(P4Parser.LCurly, 0); }
		public StatlistContext statlist() {
			return getRuleContext(StatlistContext.class,0);
		}
		public TerminalNode RCurly() { return getToken(P4Parser.RCurly, 0); }
		public WhilestatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whilestatement; }
	}

	public final WhilestatementContext whilestatement() throws RecognitionException {
		WhilestatementContext _localctx = new WhilestatementContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_whilestatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(139);
			match(T__8);
			setState(140);
			match(LParen);
			setState(141);
			expr(0);
			setState(142);
			match(RParen);
			setState(143);
			match(LCurly);
			setState(144);
			statlist();
			setState(145);
			match(RCurly);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SetstatementContext extends ParserRuleContext {
		public TerminalNode LParen() { return getToken(P4Parser.LParen, 0); }
		public SetterContext setter() {
			return getRuleContext(SetterContext.class,0);
		}
		public TerminalNode RParen() { return getToken(P4Parser.RParen, 0); }
		public SetstatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_setstatement; }
	}

	public final SetstatementContext setstatement() throws RecognitionException {
		SetstatementContext _localctx = new SetstatementContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_setstatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(147);
			match(T__9);
			setState(148);
			match(LParen);
			setState(149);
			setter();
			setState(150);
			match(RParen);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SetterContext extends ParserRuleContext {
		public List<TerminalNode> Int() { return getTokens(P4Parser.Int); }
		public TerminalNode Int(int i) {
			return getToken(P4Parser.Int, i);
		}
		public List<TerminalNode> Identifier() { return getTokens(P4Parser.Identifier); }
		public TerminalNode Identifier(int i) {
			return getToken(P4Parser.Identifier, i);
		}
		public SetterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_setter; }
	}

	public final SetterContext setter() throws RecognitionException {
		SetterContext _localctx = new SetterContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_setter);
		try {
			setState(162);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case Int:
				enterOuterAlt(_localctx, 1);
				{
				setState(152);
				match(Int);
				setState(153);
				match(T__1);
				setState(154);
				match(Int);
				setState(155);
				match(T__1);
				setState(156);
				match(Identifier);
				}
				break;
			case Identifier:
				enterOuterAlt(_localctx, 2);
				{
				setState(157);
				match(Identifier);
				setState(158);
				match(T__1);
				setState(159);
				match(Identifier);
				setState(160);
				match(T__1);
				setState(161);
				match(Identifier);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DeclContext extends ParserRuleContext {
		public TerminalNode Identifier() { return getToken(P4Parser.Identifier, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public DeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_decl; }
	}

	public final DeclContext decl() throws RecognitionException {
		DeclContext _localctx = new DeclContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_decl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(164);
			match(T__10);
			setState(165);
			match(Identifier);
			setState(166);
			match(T__4);
			setState(167);
			expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExprContext extends ParserRuleContext {
		public List<OperandContext> operand() {
			return getRuleContexts(OperandContext.class);
		}
		public OperandContext operand(int i) {
			return getRuleContext(OperandContext.class,i);
		}
		public OperatorContext operator() {
			return getRuleContext(OperatorContext.class,0);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public ExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr; }
	}

	public final ExprContext expr() throws RecognitionException {
		return expr(0);
	}

	private ExprContext expr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExprContext _localctx = new ExprContext(_ctx, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 32;
		enterRecursionRule(_localctx, 32, RULE_expr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(178);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				setState(170);
				operand();
				setState(171);
				operator();
				setState(172);
				operand();
				}
				break;
			case 2:
				{
				setState(174);
				operand();
				setState(175);
				operator();
				setState(176);
				expr(2);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(190);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(188);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
					case 1:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(180);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(181);
						operator();
						setState(182);
						expr(2);
						}
						break;
					case 2:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(184);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(185);
						operator();
						setState(186);
						operand();
						}
						break;
					}
					} 
				}
				setState(192);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class OperatorContext extends ParserRuleContext {
		public TerminalNode Less() { return getToken(P4Parser.Less, 0); }
		public TerminalNode Greater() { return getToken(P4Parser.Greater, 0); }
		public TerminalNode LessEqual() { return getToken(P4Parser.LessEqual, 0); }
		public TerminalNode GreaterEqual() { return getToken(P4Parser.GreaterEqual, 0); }
		public TerminalNode Equal() { return getToken(P4Parser.Equal, 0); }
		public TerminalNode NotEqual() { return getToken(P4Parser.NotEqual, 0); }
		public TerminalNode Plus() { return getToken(P4Parser.Plus, 0); }
		public TerminalNode Minus() { return getToken(P4Parser.Minus, 0); }
		public TerminalNode Mult() { return getToken(P4Parser.Mult, 0); }
		public TerminalNode Div() { return getToken(P4Parser.Div, 0); }
		public TerminalNode Mod() { return getToken(P4Parser.Mod, 0); }
		public TerminalNode Power() { return getToken(P4Parser.Power, 0); }
		public OperatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_operator; }
	}

	public final OperatorContext operator() throws RecognitionException {
		OperatorContext _localctx = new OperatorContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(193);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << Less) | (1L << Greater) | (1L << LessEqual) | (1L << GreaterEqual) | (1L << Equal) | (1L << NotEqual) | (1L << Plus) | (1L << Minus) | (1L << Mult) | (1L << Div) | (1L << Mod) | (1L << Power))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OperandContext extends ParserRuleContext {
		public TerminalNode Int() { return getToken(P4Parser.Int, 0); }
		public TerminalNode Identifier() { return getToken(P4Parser.Identifier, 0); }
		public OperandContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_operand; }
	}

	public final OperandContext operand() throws RecognitionException {
		OperandContext _localctx = new OperandContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_operand);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(195);
			_la = _input.LA(1);
			if ( !(_la==Int || _la==Identifier) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctiondefinitionContext extends ParserRuleContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public FunctionContext function() {
			return getRuleContext(FunctionContext.class,0);
		}
		public TerminalNode Identifier() { return getToken(P4Parser.Identifier, 0); }
		public TerminalNode LParen() { return getToken(P4Parser.LParen, 0); }
		public TypeparameterlistContext typeparameterlist() {
			return getRuleContext(TypeparameterlistContext.class,0);
		}
		public TerminalNode RParen() { return getToken(P4Parser.RParen, 0); }
		public TerminalNode LCurly() { return getToken(P4Parser.LCurly, 0); }
		public StatlistContext statlist() {
			return getRuleContext(StatlistContext.class,0);
		}
		public TerminalNode RCurly() { return getToken(P4Parser.RCurly, 0); }
		public TerminalNode Void() { return getToken(P4Parser.Void, 0); }
		public FunctiondefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functiondefinition; }
	}

	public final FunctiondefinitionContext functiondefinition() throws RecognitionException {
		FunctiondefinitionContext _localctx = new FunctiondefinitionContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_functiondefinition);
		try {
			setState(235);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(197);
				type();
				setState(198);
				function();
				setState(199);
				match(Identifier);
				setState(200);
				match(LParen);
				setState(201);
				typeparameterlist();
				setState(202);
				match(RParen);
				setState(203);
				match(LCurly);
				setState(204);
				statlist();
				setState(205);
				match(RCurly);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(207);
				type();
				setState(208);
				function();
				setState(209);
				match(Identifier);
				setState(210);
				match(LParen);
				setState(211);
				match(RParen);
				setState(212);
				match(LCurly);
				setState(213);
				statlist();
				setState(214);
				match(RCurly);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(216);
				match(Void);
				setState(217);
				function();
				setState(218);
				match(Identifier);
				setState(219);
				match(LParen);
				setState(220);
				typeparameterlist();
				setState(221);
				match(RParen);
				setState(222);
				match(LCurly);
				setState(223);
				statlist();
				setState(224);
				match(RCurly);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(226);
				match(Void);
				setState(227);
				function();
				setState(228);
				match(Identifier);
				setState(229);
				match(LParen);
				setState(230);
				match(RParen);
				setState(231);
				match(LCurly);
				setState(232);
				statlist();
				setState(233);
				match(RCurly);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypeparameterlistContext extends ParserRuleContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public ParameterContext parameter() {
			return getRuleContext(ParameterContext.class,0);
		}
		public TypeparameterlistContext typeparameterlist() {
			return getRuleContext(TypeparameterlistContext.class,0);
		}
		public TypeparameterlistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typeparameterlist; }
	}

	public final TypeparameterlistContext typeparameterlist() throws RecognitionException {
		TypeparameterlistContext _localctx = new TypeparameterlistContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_typeparameterlist);
		try {
			setState(245);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(237);
				type();
				setState(238);
				parameter();
				setState(239);
				match(T__1);
				setState(240);
				typeparameterlist();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(242);
				type();
				setState(243);
				parameter();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctioncallContext extends ParserRuleContext {
		public TerminalNode Identifier() { return getToken(P4Parser.Identifier, 0); }
		public TerminalNode LParen() { return getToken(P4Parser.LParen, 0); }
		public ParalistContext paralist() {
			return getRuleContext(ParalistContext.class,0);
		}
		public TerminalNode RParen() { return getToken(P4Parser.RParen, 0); }
		public FunctioncallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functioncall; }
	}

	public final FunctioncallContext functioncall() throws RecognitionException {
		FunctioncallContext _localctx = new FunctioncallContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_functioncall);
		try {
			setState(255);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(247);
				match(Identifier);
				setState(248);
				match(LParen);
				setState(249);
				paralist();
				setState(250);
				match(RParen);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(252);
				match(Identifier);
				setState(253);
				match(LParen);
				setState(254);
				match(RParen);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParalistContext extends ParserRuleContext {
		public ParameterContext parameter() {
			return getRuleContext(ParameterContext.class,0);
		}
		public ParalistContext paralist() {
			return getRuleContext(ParalistContext.class,0);
		}
		public ParalistContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_paralist; }
	}

	public final ParalistContext paralist() throws RecognitionException {
		ParalistContext _localctx = new ParalistContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_paralist);
		try {
			setState(262);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(257);
				parameter();
				setState(258);
				match(T__1);
				setState(259);
				paralist();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(261);
				parameter();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParameterContext extends ParserRuleContext {
		public TerminalNode Identifier() { return getToken(P4Parser.Identifier, 0); }
		public TerminalNode Int() { return getToken(P4Parser.Int, 0); }
		public ParameterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameter; }
	}

	public final ParameterContext parameter() throws RecognitionException {
		ParameterContext _localctx = new ParameterContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_parameter);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(264);
			_la = _input.LA(1);
			if ( !(_la==Int || _la==Identifier) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class KeywordsContext extends ParserRuleContext {
		public TerminalNode Void() { return getToken(P4Parser.Void, 0); }
		public KeywordsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_keywords; }
	}

	public final KeywordsContext keywords() throws RecognitionException {
		KeywordsContext _localctx = new KeywordsContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_keywords);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(266);
			match(Void);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypeContext extends ParserRuleContext {
		public TerminalNode Int() { return getToken(P4Parser.Int, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_type);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(268);
			match(Int);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 1:
			return initialSetup_sempred((InitialSetupContext)_localctx, predIndex);
		case 16:
			return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean initialSetup_sempred(InitialSetupContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 1);
		}
		return true;
	}
	private boolean expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1:
			return precpred(_ctx, 1);
		case 2:
			return precpred(_ctx, 3);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3%\u0111\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\3\2\5\28\n\2\3\2\3\2\3\3\3\3\3\3\3\3\3\3\7\3A\n\3"+
		"\f\3\16\3D\13\3\3\4\3\4\3\4\3\4\3\4\5\4K\n\4\3\5\3\5\3\5\3\5\3\5\3\5\3"+
		"\5\3\5\3\6\3\6\3\6\3\6\5\6Y\n\6\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\5"+
		"\bd\n\b\3\t\3\t\3\t\3\t\3\t\3\t\5\tl\n\t\3\n\3\n\3\n\3\n\5\nr\n\n\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r"+
		"\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\16"+
		"\3\16\3\17\3\17\3\17\3\17\3\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20"+
		"\3\20\3\20\5\20\u00a5\n\20\3\21\3\21\3\21\3\21\3\21\3\22\3\22\3\22\3\22"+
		"\3\22\3\22\3\22\3\22\3\22\5\22\u00b5\n\22\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\22\7\22\u00bf\n\22\f\22\16\22\u00c2\13\22\3\23\3\23\3\24\3\24"+
		"\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25"+
		"\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25"+
		"\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\5\25\u00ee\n\25\3\26"+
		"\3\26\3\26\3\26\3\26\3\26\3\26\3\26\5\26\u00f8\n\26\3\27\3\27\3\27\3\27"+
		"\3\27\3\27\3\27\3\27\5\27\u0102\n\27\3\30\3\30\3\30\3\30\3\30\5\30\u0109"+
		"\n\30\3\31\3\31\3\32\3\32\3\33\3\33\3\33\2\4\4\"\34\2\4\6\b\n\f\16\20"+
		"\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\2\4\3\2\21\34\4\2\16\16\20\20"+
		"\2\u010e\2\67\3\2\2\2\4;\3\2\2\2\6J\3\2\2\2\bL\3\2\2\2\nX\3\2\2\2\fZ\3"+
		"\2\2\2\16c\3\2\2\2\20k\3\2\2\2\22q\3\2\2\2\24s\3\2\2\2\26y\3\2\2\2\30"+
		"\u0081\3\2\2\2\32\u008d\3\2\2\2\34\u0095\3\2\2\2\36\u00a4\3\2\2\2 \u00a6"+
		"\3\2\2\2\"\u00b4\3\2\2\2$\u00c3\3\2\2\2&\u00c5\3\2\2\2(\u00ed\3\2\2\2"+
		"*\u00f7\3\2\2\2,\u0101\3\2\2\2.\u0108\3\2\2\2\60\u010a\3\2\2\2\62\u010c"+
		"\3\2\2\2\64\u010e\3\2\2\2\668\5\4\3\2\67\66\3\2\2\2\678\3\2\2\289\3\2"+
		"\2\29:\7\2\2\3:\3\3\2\2\2;<\b\3\1\2<=\5\6\4\2=B\3\2\2\2>?\f\3\2\2?A\5"+
		"\6\4\2@>\3\2\2\2AD\3\2\2\2B@\3\2\2\2BC\3\2\2\2C\5\3\2\2\2DB\3\2\2\2EK"+
		"\5\b\5\2FK\5(\25\2GK\5\f\7\2HK\5\24\13\2IK\5 \21\2JE\3\2\2\2JF\3\2\2\2"+
		"JG\3\2\2\2JH\3\2\2\2JI\3\2\2\2K\7\3\2\2\2LM\7\3\2\2MN\7\16\2\2NO\7\4\2"+
		"\2OP\7\16\2\2PQ\7\5\2\2QR\5\n\6\2RS\7\6\2\2S\t\3\2\2\2TU\7\20\2\2UV\7"+
		"\4\2\2VY\5\n\6\2WY\7\20\2\2XT\3\2\2\2XW\3\2\2\2Y\13\3\2\2\2Z[\5(\25\2"+
		"[\\\5\f\7\2\\\r\3\2\2\2]d\5\20\t\2^d\5\26\f\2_d\5\30\r\2`d\5\34\17\2a"+
		"d\5\32\16\2bd\5,\27\2c]\3\2\2\2c^\3\2\2\2c_\3\2\2\2c`\3\2\2\2ca\3\2\2"+
		"\2cb\3\2\2\2d\17\3\2\2\2ef\7\20\2\2fg\7\7\2\2gl\5\"\22\2hi\7\20\2\2ij"+
		"\7\7\2\2jl\7\16\2\2ke\3\2\2\2kh\3\2\2\2l\21\3\2\2\2mn\5\16\b\2no\5\22"+
		"\n\2or\3\2\2\2pr\3\2\2\2qm\3\2\2\2qp\3\2\2\2r\23\3\2\2\2st\7\b\2\2tu\7"+
		"\20\2\2uv\7\37\2\2vw\5\22\n\2wx\7 \2\2x\25\3\2\2\2yz\7\t\2\2z{\7\35\2"+
		"\2{|\5\"\22\2|}\7\36\2\2}~\7\37\2\2~\177\5\22\n\2\177\u0080\7 \2\2\u0080"+
		"\27\3\2\2\2\u0081\u0082\7\n\2\2\u0082\u0083\7\35\2\2\u0083\u0084\5\20"+
		"\t\2\u0084\u0085\7\6\2\2\u0085\u0086\5\"\22\2\u0086\u0087\7\6\2\2\u0087"+
		"\u0088\5\16\b\2\u0088\u0089\7\36\2\2\u0089\u008a\7\37\2\2\u008a\u008b"+
		"\5\22\n\2\u008b\u008c\7 \2\2\u008c\31\3\2\2\2\u008d\u008e\7\13\2\2\u008e"+
		"\u008f\7\35\2\2\u008f\u0090\5\"\22\2\u0090\u0091\7\36\2\2\u0091\u0092"+
		"\7\37\2\2\u0092\u0093\5\22\n\2\u0093\u0094\7 \2\2\u0094\33\3\2\2\2\u0095"+
		"\u0096\7\f\2\2\u0096\u0097\7\35\2\2\u0097\u0098\5\36\20\2\u0098\u0099"+
		"\7\36\2\2\u0099\35\3\2\2\2\u009a\u009b\7\16\2\2\u009b\u009c\7\4\2\2\u009c"+
		"\u009d\7\16\2\2\u009d\u009e\7\4\2\2\u009e\u00a5\7\20\2\2\u009f\u00a0\7"+
		"\20\2\2\u00a0\u00a1\7\4\2\2\u00a1\u00a2\7\20\2\2\u00a2\u00a3\7\4\2\2\u00a3"+
		"\u00a5\7\20\2\2\u00a4\u009a\3\2\2\2\u00a4\u009f\3\2\2\2\u00a5\37\3\2\2"+
		"\2\u00a6\u00a7\7\r\2\2\u00a7\u00a8\7\20\2\2\u00a8\u00a9\7\7\2\2\u00a9"+
		"\u00aa\5\"\22\2\u00aa!\3\2\2\2\u00ab\u00ac\b\22\1\2\u00ac\u00ad\5&\24"+
		"\2\u00ad\u00ae\5$\23\2\u00ae\u00af\5&\24\2\u00af\u00b5\3\2\2\2\u00b0\u00b1"+
		"\5&\24\2\u00b1\u00b2\5$\23\2\u00b2\u00b3\5\"\22\4\u00b3\u00b5\3\2\2\2"+
		"\u00b4\u00ab\3\2\2\2\u00b4\u00b0\3\2\2\2\u00b5\u00c0\3\2\2\2\u00b6\u00b7"+
		"\f\3\2\2\u00b7\u00b8\5$\23\2\u00b8\u00b9\5\"\22\4\u00b9\u00bf\3\2\2\2"+
		"\u00ba\u00bb\f\5\2\2\u00bb\u00bc\5$\23\2\u00bc\u00bd\5&\24\2\u00bd\u00bf"+
		"\3\2\2\2\u00be\u00b6\3\2\2\2\u00be\u00ba\3\2\2\2\u00bf\u00c2\3\2\2\2\u00c0"+
		"\u00be\3\2\2\2\u00c0\u00c1\3\2\2\2\u00c1#\3\2\2\2\u00c2\u00c0\3\2\2\2"+
		"\u00c3\u00c4\t\2\2\2\u00c4%\3\2\2\2\u00c5\u00c6\t\3\2\2\u00c6\'\3\2\2"+
		"\2\u00c7\u00c8\5\64\33\2\u00c8\u00c9\5\f\7\2\u00c9\u00ca\7\20\2\2\u00ca"+
		"\u00cb\7\35\2\2\u00cb\u00cc\5*\26\2\u00cc\u00cd\7\36\2\2\u00cd\u00ce\7"+
		"\37\2\2\u00ce\u00cf\5\22\n\2\u00cf\u00d0\7 \2\2\u00d0\u00ee\3\2\2\2\u00d1"+
		"\u00d2\5\64\33\2\u00d2\u00d3\5\f\7\2\u00d3\u00d4\7\20\2\2\u00d4\u00d5"+
		"\7\35\2\2\u00d5\u00d6\7\36\2\2\u00d6\u00d7\7\37\2\2\u00d7\u00d8\5\22\n"+
		"\2\u00d8\u00d9\7 \2\2\u00d9\u00ee\3\2\2\2\u00da\u00db\7!\2\2\u00db\u00dc"+
		"\5\f\7\2\u00dc\u00dd\7\20\2\2\u00dd\u00de\7\35\2\2\u00de\u00df\5*\26\2"+
		"\u00df\u00e0\7\36\2\2\u00e0\u00e1\7\37\2\2\u00e1\u00e2\5\22\n\2\u00e2"+
		"\u00e3\7 \2\2\u00e3\u00ee\3\2\2\2\u00e4\u00e5\7!\2\2\u00e5\u00e6\5\f\7"+
		"\2\u00e6\u00e7\7\20\2\2\u00e7\u00e8\7\35\2\2\u00e8\u00e9\7\36\2\2\u00e9"+
		"\u00ea\7\37\2\2\u00ea\u00eb\5\22\n\2\u00eb\u00ec\7 \2\2\u00ec\u00ee\3"+
		"\2\2\2\u00ed\u00c7\3\2\2\2\u00ed\u00d1\3\2\2\2\u00ed\u00da\3\2\2\2\u00ed"+
		"\u00e4\3\2\2\2\u00ee)\3\2\2\2\u00ef\u00f0\5\64\33\2\u00f0\u00f1\5\60\31"+
		"\2\u00f1\u00f2\7\4\2\2\u00f2\u00f3\5*\26\2\u00f3\u00f8\3\2\2\2\u00f4\u00f5"+
		"\5\64\33\2\u00f5\u00f6\5\60\31\2\u00f6\u00f8\3\2\2\2\u00f7\u00ef\3\2\2"+
		"\2\u00f7\u00f4\3\2\2\2\u00f8+\3\2\2\2\u00f9\u00fa\7\20\2\2\u00fa\u00fb"+
		"\7\35\2\2\u00fb\u00fc\5.\30\2\u00fc\u00fd\7\36\2\2\u00fd\u0102\3\2\2\2"+
		"\u00fe\u00ff\7\20\2\2\u00ff\u0100\7\35\2\2\u0100\u0102\7\36\2\2\u0101"+
		"\u00f9\3\2\2\2\u0101\u00fe\3\2\2\2\u0102-\3\2\2\2\u0103\u0104\5\60\31"+
		"\2\u0104\u0105\7\4\2\2\u0105\u0106\5.\30\2\u0106\u0109\3\2\2\2\u0107\u0109"+
		"\5\60\31\2\u0108\u0103\3\2\2\2\u0108\u0107\3\2\2\2\u0109/\3\2\2\2\u010a"+
		"\u010b\t\3\2\2\u010b\61\3\2\2\2\u010c\u010d\7!\2\2\u010d\63\3\2\2\2\u010e"+
		"\u010f\7\16\2\2\u010f\65\3\2\2\2\21\67BJXckq\u00a4\u00b4\u00be\u00c0\u00ed"+
		"\u00f7\u0101\u0108";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}