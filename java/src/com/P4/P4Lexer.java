package com.P4;

// Generated from P4.G4 by ANTLR 4.8
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.ATN;
import org.antlr.v4.runtime.atn.ATNDeserializer;
import org.antlr.v4.runtime.atn.LexerATNSimulator;
import org.antlr.v4.runtime.atn.PredictionContextCache;
import org.antlr.v4.runtime.dfa.DFA;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class P4Lexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, Int=12, Float=13, Identifier=14, Less=15, Greater=16, 
		LessEqual=17, GreaterEqual=18, Equal=19, NotEqual=20, Plus=21, Minus=22, 
		Mult=23, Div=24, Mod=25, Power=26, LParen=27, RParen=28, LCurly=29, RCurly=30, 
		Void=31, Whitespace=32, CR=33, NL=34, CRNL=35;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
			"T__9", "T__10", "Int", "Float", "Identifier", "IdentifierNondigit", 
			"Digit", "Nondigit", "Less", "Greater", "LessEqual", "GreaterEqual", 
			"Equal", "NotEqual", "Plus", "Minus", "Mult", "Div", "Mod", "Power", 
			"LParen", "RParen", "LCurly", "RCurly", "Void", "Whitespace", "CR", "NL", 
			"CRNL"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'grid:'", "','", "'states:'", "';'", "'='", "'RULE'", "'if'", 
			"'for'", "'while'", "'set'", "'int'", null, null, null, "'<'", "'>'", 
			"'<='", "'>='", "'=='", "'!='", "'+'", "'-'", "'*'", "'/'", "'%'", "'^'", 
			"'('", "')'", "'{'", "'}'", "'void'", null, "'\r'", "'\n'", "'\r\n'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			"Int", "Float", "Identifier", "Less", "Greater", "LessEqual", "GreaterEqual", 
			"Equal", "NotEqual", "Plus", "Minus", "Mult", "Div", "Mod", "Power", 
			"LParen", "RParen", "LCurly", "RCurly", "Void", "Whitespace", "CR", "NL", 
			"CRNL"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
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


	public P4Lexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "P4.G4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2%\u00d1\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\3\2\3\2\3\2\3\2\3\2\3\2\3"+
		"\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\7\3\7"+
		"\3\7\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3\13\3\13"+
		"\3\13\3\f\3\f\3\f\3\f\3\r\6\r\177\n\r\r\r\16\r\u0080\3\16\6\16\u0084\n"+
		"\16\r\16\16\16\u0085\3\16\3\16\3\17\3\17\3\17\7\17\u008d\n\17\f\17\16"+
		"\17\u0090\13\17\3\20\3\20\3\21\3\21\3\22\3\22\3\23\3\23\3\24\3\24\3\25"+
		"\3\25\3\25\3\26\3\26\3\26\3\27\3\27\3\27\3\30\3\30\3\30\3\31\3\31\3\32"+
		"\3\32\3\33\3\33\3\34\3\34\3\35\3\35\3\36\3\36\3\37\3\37\3 \3 \3!\3!\3"+
		"\"\3\"\3#\3#\3#\3#\3#\3$\3$\3$\3$\3%\3%\3%\3%\3&\3&\3&\3&\3\'\3\'\3\'"+
		"\3\'\3\'\2\2(\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16"+
		"\33\17\35\20\37\2!\2#\2%\21\'\22)\23+\24-\25/\26\61\27\63\30\65\31\67"+
		"\329\33;\34=\35?\36A\37C E!G\"I#K$M%\3\2\5\3\2\62;\5\2C\\aac|\5\2\13\13"+
		"\16\16\"\"\2\u00d1\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13"+
		"\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2"+
		"\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2%\3\2\2\2\2\'"+
		"\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63"+
		"\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2"+
		"?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3"+
		"\2\2\2\2M\3\2\2\2\3O\3\2\2\2\5U\3\2\2\2\7W\3\2\2\2\t_\3\2\2\2\13a\3\2"+
		"\2\2\rc\3\2\2\2\17h\3\2\2\2\21k\3\2\2\2\23o\3\2\2\2\25u\3\2\2\2\27y\3"+
		"\2\2\2\31~\3\2\2\2\33\u0083\3\2\2\2\35\u0089\3\2\2\2\37\u0091\3\2\2\2"+
		"!\u0093\3\2\2\2#\u0095\3\2\2\2%\u0097\3\2\2\2\'\u0099\3\2\2\2)\u009b\3"+
		"\2\2\2+\u009e\3\2\2\2-\u00a1\3\2\2\2/\u00a4\3\2\2\2\61\u00a7\3\2\2\2\63"+
		"\u00a9\3\2\2\2\65\u00ab\3\2\2\2\67\u00ad\3\2\2\29\u00af\3\2\2\2;\u00b1"+
		"\3\2\2\2=\u00b3\3\2\2\2?\u00b5\3\2\2\2A\u00b7\3\2\2\2C\u00b9\3\2\2\2E"+
		"\u00bb\3\2\2\2G\u00c0\3\2\2\2I\u00c4\3\2\2\2K\u00c8\3\2\2\2M\u00cc\3\2"+
		"\2\2OP\7i\2\2PQ\7t\2\2QR\7k\2\2RS\7f\2\2ST\7<\2\2T\4\3\2\2\2UV\7.\2\2"+
		"V\6\3\2\2\2WX\7u\2\2XY\7v\2\2YZ\7c\2\2Z[\7v\2\2[\\\7g\2\2\\]\7u\2\2]^"+
		"\7<\2\2^\b\3\2\2\2_`\7=\2\2`\n\3\2\2\2ab\7?\2\2b\f\3\2\2\2cd\7T\2\2de"+
		"\7W\2\2ef\7N\2\2fg\7G\2\2g\16\3\2\2\2hi\7k\2\2ij\7h\2\2j\20\3\2\2\2kl"+
		"\7h\2\2lm\7q\2\2mn\7t\2\2n\22\3\2\2\2op\7y\2\2pq\7j\2\2qr\7k\2\2rs\7n"+
		"\2\2st\7g\2\2t\24\3\2\2\2uv\7u\2\2vw\7g\2\2wx\7v\2\2x\26\3\2\2\2yz\7k"+
		"\2\2z{\7p\2\2{|\7v\2\2|\30\3\2\2\2}\177\5!\21\2~}\3\2\2\2\177\u0080\3"+
		"\2\2\2\u0080~\3\2\2\2\u0080\u0081\3\2\2\2\u0081\32\3\2\2\2\u0082\u0084"+
		"\5!\21\2\u0083\u0082\3\2\2\2\u0084\u0085\3\2\2\2\u0085\u0083\3\2\2\2\u0085"+
		"\u0086\3\2\2\2\u0086\u0087\3\2\2\2\u0087\u0088\7\60\2\2\u0088\34\3\2\2"+
		"\2\u0089\u008e\5\37\20\2\u008a\u008d\5\37\20\2\u008b\u008d\5!\21\2\u008c"+
		"\u008a\3\2\2\2\u008c\u008b\3\2\2\2\u008d\u0090\3\2\2\2\u008e\u008c\3\2"+
		"\2\2\u008e\u008f\3\2\2\2\u008f\36\3\2\2\2\u0090\u008e\3\2\2\2\u0091\u0092"+
		"\5#\22\2\u0092 \3\2\2\2\u0093\u0094\t\2\2\2\u0094\"\3\2\2\2\u0095\u0096"+
		"\t\3\2\2\u0096$\3\2\2\2\u0097\u0098\7>\2\2\u0098&\3\2\2\2\u0099\u009a"+
		"\7@\2\2\u009a(\3\2\2\2\u009b\u009c\7>\2\2\u009c\u009d\7?\2\2\u009d*\3"+
		"\2\2\2\u009e\u009f\7@\2\2\u009f\u00a0\7?\2\2\u00a0,\3\2\2\2\u00a1\u00a2"+
		"\7?\2\2\u00a2\u00a3\7?\2\2\u00a3.\3\2\2\2\u00a4\u00a5\7#\2\2\u00a5\u00a6"+
		"\7?\2\2\u00a6\60\3\2\2\2\u00a7\u00a8\7-\2\2\u00a8\62\3\2\2\2\u00a9\u00aa"+
		"\7/\2\2\u00aa\64\3\2\2\2\u00ab\u00ac\7,\2\2\u00ac\66\3\2\2\2\u00ad\u00ae"+
		"\7\61\2\2\u00ae8\3\2\2\2\u00af\u00b0\7\'\2\2\u00b0:\3\2\2\2\u00b1\u00b2"+
		"\7`\2\2\u00b2<\3\2\2\2\u00b3\u00b4\7*\2\2\u00b4>\3\2\2\2\u00b5\u00b6\7"+
		"+\2\2\u00b6@\3\2\2\2\u00b7\u00b8\7}\2\2\u00b8B\3\2\2\2\u00b9\u00ba\7\177"+
		"\2\2\u00baD\3\2\2\2\u00bb\u00bc\7x\2\2\u00bc\u00bd\7q\2\2\u00bd\u00be"+
		"\7k\2\2\u00be\u00bf\7f\2\2\u00bfF\3\2\2\2\u00c0\u00c1\t\4\2\2\u00c1\u00c2"+
		"\3\2\2\2\u00c2\u00c3\b$\2\2\u00c3H\3\2\2\2\u00c4\u00c5\7\17\2\2\u00c5"+
		"\u00c6\3\2\2\2\u00c6\u00c7\b%\2\2\u00c7J\3\2\2\2\u00c8\u00c9\7\f\2\2\u00c9"+
		"\u00ca\3\2\2\2\u00ca\u00cb\b&\2\2\u00cbL\3\2\2\2\u00cc\u00cd\7\17\2\2"+
		"\u00cd\u00ce\7\f\2\2\u00ce\u00cf\3\2\2\2\u00cf\u00d0\b\'\2\2\u00d0N\3"+
		"\2\2\2\7\2\u0080\u0085\u008c\u008e\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}