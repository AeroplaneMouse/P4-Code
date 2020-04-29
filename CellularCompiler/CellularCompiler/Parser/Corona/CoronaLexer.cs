//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Grammar/Corona.g4 by ANTLR 4.7.2

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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class CoronaLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, T__26=27, T__27=28, T__28=29, T__29=30, T__30=31, 
		T__31=32, T__32=33, ID=34, INT=35, STRING=36, COMMENT=37, WS=38, CR=39, 
		NL=40, CRNL=41, TAB=42;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "T__23", "T__24", 
		"T__25", "T__26", "T__27", "T__28", "T__29", "T__30", "T__31", "T__32", 
		"DIGIT", "Nondigit", "ID", "INT", "STRING", "COMMENT", "WS", "CR", "NL", 
		"CRNL", "TAB"
	};


	public CoronaLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public CoronaLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'GRID'", "'{'", "'}'", "'STATES'", "','", "'INITIAL'", "'RULES'", 
		"':'", "';'", "'match'", "'('", "'state'", "')'", "'for'", "'='", "'return'", 
		"'['", "']'", "'+'", "'-'", "'*'", "'/'", "'=='", "'!='", "'<'", "'>'", 
		"'<='", "'>='", "'_'", "'0'", "'->'", "'.'", "'grid['", null, null, null, 
		null, null, "'\r'", "'\n'", "'\r\n'", "'\t'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, "ID", "INT", 
		"STRING", "COMMENT", "WS", "CR", "NL", "CRNL", "TAB"
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

	public override string GrammarFileName { get { return "Corona.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static CoronaLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', ',', '\x106', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', '\x4', ',', '\t', 
		',', '\x4', '-', '\t', '-', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', 
		'\a', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', 
		'\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', 
		'\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', 
		'\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', '\x14', 
		'\x3', '\x15', '\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', '\x17', 
		'\x3', '\x17', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x19', 
		'\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', 
		'\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', 
		'\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', 
		'!', '\x3', '\"', '\x3', '\"', '\x3', '\"', '\x3', '\"', '\x3', '\"', 
		'\x3', '\"', '\x3', '#', '\x3', '#', '\x3', '$', '\x3', '$', '\x3', '%', 
		'\x3', '%', '\x3', '%', '\a', '%', '\xCF', '\n', '%', '\f', '%', '\xE', 
		'%', '\xD2', '\v', '%', '\x3', '&', '\x3', '&', '\x3', '&', '\a', '&', 
		'\xD7', '\n', '&', '\f', '&', '\xE', '&', '\xDA', '\v', '&', '\x5', '&', 
		'\xDC', '\n', '&', '\x3', '\'', '\x3', '\'', '\a', '\'', '\xE0', '\n', 
		'\'', '\f', '\'', '\xE', '\'', '\xE3', '\v', '\'', '\x3', '\'', '\x3', 
		'\'', '\x3', '(', '\x3', '(', '\a', '(', '\xE9', '\n', '(', '\f', '(', 
		'\xE', '(', '\xEC', '\v', '(', '\x3', '(', '\x3', '(', '\x3', '(', '\x3', 
		'(', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', '*', '\x3', 
		'*', '\x3', '*', '\x3', '*', '\x3', '+', '\x3', '+', '\x3', '+', '\x3', 
		'+', '\x3', ',', '\x3', ',', '\x3', ',', '\x3', ',', '\x3', ',', '\x3', 
		'-', '\x3', '-', '\x3', '-', '\x3', '-', '\x4', '\xE1', '\xEA', '\x2', 
		'.', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', 
		'\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', '\x17', 
		'\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', '!', 
		'\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', '\x16', '+', '\x17', 
		'-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', '\x1B', '\x35', '\x1C', 
		'\x37', '\x1D', '\x39', '\x1E', ';', '\x1F', '=', ' ', '?', '!', '\x41', 
		'\"', '\x43', '#', '\x45', '\x2', 'G', '\x2', 'I', '$', 'K', '%', 'M', 
		'&', 'O', '\'', 'Q', '(', 'S', ')', 'U', '*', 'W', '+', 'Y', ',', '\x3', 
		'\x2', '\x6', '\x3', '\x2', '\x32', ';', '\x5', '\x2', '\x43', '\\', '\x61', 
		'\x61', '\x63', '|', '\x3', '\x2', '\x33', ';', '\x5', '\x2', '\v', '\v', 
		'\xE', '\xE', '\"', '\"', '\x2', '\x109', '\x2', '\x3', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\xF', '\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\'', '\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x33', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x39', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x41', '\x3', '\x2', '\x2', '\x2', '\x2', '\x43', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'I', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'K', '\x3', '\x2', '\x2', '\x2', '\x2', 'M', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'O', '\x3', '\x2', '\x2', '\x2', '\x2', 'Q', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'S', '\x3', '\x2', '\x2', '\x2', '\x2', 'U', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'W', '\x3', '\x2', '\x2', '\x2', '\x2', 'Y', '\x3', 
		'\x2', '\x2', '\x2', '\x3', '[', '\x3', '\x2', '\x2', '\x2', '\x5', '`', 
		'\x3', '\x2', '\x2', '\x2', '\a', '\x62', '\x3', '\x2', '\x2', '\x2', 
		'\t', '\x64', '\x3', '\x2', '\x2', '\x2', '\v', 'k', '\x3', '\x2', '\x2', 
		'\x2', '\r', 'm', '\x3', '\x2', '\x2', '\x2', '\xF', 'u', '\x3', '\x2', 
		'\x2', '\x2', '\x11', '{', '\x3', '\x2', '\x2', '\x2', '\x13', '}', '\x3', 
		'\x2', '\x2', '\x2', '\x15', '\x7F', '\x3', '\x2', '\x2', '\x2', '\x17', 
		'\x85', '\x3', '\x2', '\x2', '\x2', '\x19', '\x87', '\x3', '\x2', '\x2', 
		'\x2', '\x1B', '\x8D', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x8F', '\x3', 
		'\x2', '\x2', '\x2', '\x1F', '\x93', '\x3', '\x2', '\x2', '\x2', '!', 
		'\x95', '\x3', '\x2', '\x2', '\x2', '#', '\x9C', '\x3', '\x2', '\x2', 
		'\x2', '%', '\x9E', '\x3', '\x2', '\x2', '\x2', '\'', '\xA0', '\x3', '\x2', 
		'\x2', '\x2', ')', '\xA2', '\x3', '\x2', '\x2', '\x2', '+', '\xA4', '\x3', 
		'\x2', '\x2', '\x2', '-', '\xA6', '\x3', '\x2', '\x2', '\x2', '/', '\xA8', 
		'\x3', '\x2', '\x2', '\x2', '\x31', '\xAB', '\x3', '\x2', '\x2', '\x2', 
		'\x33', '\xAE', '\x3', '\x2', '\x2', '\x2', '\x35', '\xB0', '\x3', '\x2', 
		'\x2', '\x2', '\x37', '\xB2', '\x3', '\x2', '\x2', '\x2', '\x39', '\xB5', 
		'\x3', '\x2', '\x2', '\x2', ';', '\xB8', '\x3', '\x2', '\x2', '\x2', '=', 
		'\xBA', '\x3', '\x2', '\x2', '\x2', '?', '\xBC', '\x3', '\x2', '\x2', 
		'\x2', '\x41', '\xBF', '\x3', '\x2', '\x2', '\x2', '\x43', '\xC1', '\x3', 
		'\x2', '\x2', '\x2', '\x45', '\xC7', '\x3', '\x2', '\x2', '\x2', 'G', 
		'\xC9', '\x3', '\x2', '\x2', '\x2', 'I', '\xCB', '\x3', '\x2', '\x2', 
		'\x2', 'K', '\xDB', '\x3', '\x2', '\x2', '\x2', 'M', '\xDD', '\x3', '\x2', 
		'\x2', '\x2', 'O', '\xE6', '\x3', '\x2', '\x2', '\x2', 'Q', '\xF1', '\x3', 
		'\x2', '\x2', '\x2', 'S', '\xF5', '\x3', '\x2', '\x2', '\x2', 'U', '\xF9', 
		'\x3', '\x2', '\x2', '\x2', 'W', '\xFD', '\x3', '\x2', '\x2', '\x2', 'Y', 
		'\x102', '\x3', '\x2', '\x2', '\x2', '[', '\\', '\a', 'I', '\x2', '\x2', 
		'\\', ']', '\a', 'T', '\x2', '\x2', ']', '^', '\a', 'K', '\x2', '\x2', 
		'^', '_', '\a', '\x46', '\x2', '\x2', '_', '\x4', '\x3', '\x2', '\x2', 
		'\x2', '`', '\x61', '\a', '}', '\x2', '\x2', '\x61', '\x6', '\x3', '\x2', 
		'\x2', '\x2', '\x62', '\x63', '\a', '\x7F', '\x2', '\x2', '\x63', '\b', 
		'\x3', '\x2', '\x2', '\x2', '\x64', '\x65', '\a', 'U', '\x2', '\x2', '\x65', 
		'\x66', '\a', 'V', '\x2', '\x2', '\x66', 'g', '\a', '\x43', '\x2', '\x2', 
		'g', 'h', '\a', 'V', '\x2', '\x2', 'h', 'i', '\a', 'G', '\x2', '\x2', 
		'i', 'j', '\a', 'U', '\x2', '\x2', 'j', '\n', '\x3', '\x2', '\x2', '\x2', 
		'k', 'l', '\a', '.', '\x2', '\x2', 'l', '\f', '\x3', '\x2', '\x2', '\x2', 
		'm', 'n', '\a', 'K', '\x2', '\x2', 'n', 'o', '\a', 'P', '\x2', '\x2', 
		'o', 'p', '\a', 'K', '\x2', '\x2', 'p', 'q', '\a', 'V', '\x2', '\x2', 
		'q', 'r', '\a', 'K', '\x2', '\x2', 'r', 's', '\a', '\x43', '\x2', '\x2', 
		's', 't', '\a', 'N', '\x2', '\x2', 't', '\xE', '\x3', '\x2', '\x2', '\x2', 
		'u', 'v', '\a', 'T', '\x2', '\x2', 'v', 'w', '\a', 'W', '\x2', '\x2', 
		'w', 'x', '\a', 'N', '\x2', '\x2', 'x', 'y', '\a', 'G', '\x2', '\x2', 
		'y', 'z', '\a', 'U', '\x2', '\x2', 'z', '\x10', '\x3', '\x2', '\x2', '\x2', 
		'{', '|', '\a', '<', '\x2', '\x2', '|', '\x12', '\x3', '\x2', '\x2', '\x2', 
		'}', '~', '\a', '=', '\x2', '\x2', '~', '\x14', '\x3', '\x2', '\x2', '\x2', 
		'\x7F', '\x80', '\a', 'o', '\x2', '\x2', '\x80', '\x81', '\a', '\x63', 
		'\x2', '\x2', '\x81', '\x82', '\a', 'v', '\x2', '\x2', '\x82', '\x83', 
		'\a', '\x65', '\x2', '\x2', '\x83', '\x84', '\a', 'j', '\x2', '\x2', '\x84', 
		'\x16', '\x3', '\x2', '\x2', '\x2', '\x85', '\x86', '\a', '*', '\x2', 
		'\x2', '\x86', '\x18', '\x3', '\x2', '\x2', '\x2', '\x87', '\x88', '\a', 
		'u', '\x2', '\x2', '\x88', '\x89', '\a', 'v', '\x2', '\x2', '\x89', '\x8A', 
		'\a', '\x63', '\x2', '\x2', '\x8A', '\x8B', '\a', 'v', '\x2', '\x2', '\x8B', 
		'\x8C', '\a', 'g', '\x2', '\x2', '\x8C', '\x1A', '\x3', '\x2', '\x2', 
		'\x2', '\x8D', '\x8E', '\a', '+', '\x2', '\x2', '\x8E', '\x1C', '\x3', 
		'\x2', '\x2', '\x2', '\x8F', '\x90', '\a', 'h', '\x2', '\x2', '\x90', 
		'\x91', '\a', 'q', '\x2', '\x2', '\x91', '\x92', '\a', 't', '\x2', '\x2', 
		'\x92', '\x1E', '\x3', '\x2', '\x2', '\x2', '\x93', '\x94', '\a', '?', 
		'\x2', '\x2', '\x94', ' ', '\x3', '\x2', '\x2', '\x2', '\x95', '\x96', 
		'\a', 't', '\x2', '\x2', '\x96', '\x97', '\a', 'g', '\x2', '\x2', '\x97', 
		'\x98', '\a', 'v', '\x2', '\x2', '\x98', '\x99', '\a', 'w', '\x2', '\x2', 
		'\x99', '\x9A', '\a', 't', '\x2', '\x2', '\x9A', '\x9B', '\a', 'p', '\x2', 
		'\x2', '\x9B', '\"', '\x3', '\x2', '\x2', '\x2', '\x9C', '\x9D', '\a', 
		']', '\x2', '\x2', '\x9D', '$', '\x3', '\x2', '\x2', '\x2', '\x9E', '\x9F', 
		'\a', '_', '\x2', '\x2', '\x9F', '&', '\x3', '\x2', '\x2', '\x2', '\xA0', 
		'\xA1', '\a', '-', '\x2', '\x2', '\xA1', '(', '\x3', '\x2', '\x2', '\x2', 
		'\xA2', '\xA3', '\a', '/', '\x2', '\x2', '\xA3', '*', '\x3', '\x2', '\x2', 
		'\x2', '\xA4', '\xA5', '\a', ',', '\x2', '\x2', '\xA5', ',', '\x3', '\x2', 
		'\x2', '\x2', '\xA6', '\xA7', '\a', '\x31', '\x2', '\x2', '\xA7', '.', 
		'\x3', '\x2', '\x2', '\x2', '\xA8', '\xA9', '\a', '?', '\x2', '\x2', '\xA9', 
		'\xAA', '\a', '?', '\x2', '\x2', '\xAA', '\x30', '\x3', '\x2', '\x2', 
		'\x2', '\xAB', '\xAC', '\a', '#', '\x2', '\x2', '\xAC', '\xAD', '\a', 
		'?', '\x2', '\x2', '\xAD', '\x32', '\x3', '\x2', '\x2', '\x2', '\xAE', 
		'\xAF', '\a', '>', '\x2', '\x2', '\xAF', '\x34', '\x3', '\x2', '\x2', 
		'\x2', '\xB0', '\xB1', '\a', '@', '\x2', '\x2', '\xB1', '\x36', '\x3', 
		'\x2', '\x2', '\x2', '\xB2', '\xB3', '\a', '>', '\x2', '\x2', '\xB3', 
		'\xB4', '\a', '?', '\x2', '\x2', '\xB4', '\x38', '\x3', '\x2', '\x2', 
		'\x2', '\xB5', '\xB6', '\a', '@', '\x2', '\x2', '\xB6', '\xB7', '\a', 
		'?', '\x2', '\x2', '\xB7', ':', '\x3', '\x2', '\x2', '\x2', '\xB8', '\xB9', 
		'\a', '\x61', '\x2', '\x2', '\xB9', '<', '\x3', '\x2', '\x2', '\x2', '\xBA', 
		'\xBB', '\a', '\x32', '\x2', '\x2', '\xBB', '>', '\x3', '\x2', '\x2', 
		'\x2', '\xBC', '\xBD', '\a', '/', '\x2', '\x2', '\xBD', '\xBE', '\a', 
		'@', '\x2', '\x2', '\xBE', '@', '\x3', '\x2', '\x2', '\x2', '\xBF', '\xC0', 
		'\a', '\x30', '\x2', '\x2', '\xC0', '\x42', '\x3', '\x2', '\x2', '\x2', 
		'\xC1', '\xC2', '\a', 'i', '\x2', '\x2', '\xC2', '\xC3', '\a', 't', '\x2', 
		'\x2', '\xC3', '\xC4', '\a', 'k', '\x2', '\x2', '\xC4', '\xC5', '\a', 
		'\x66', '\x2', '\x2', '\xC5', '\xC6', '\a', ']', '\x2', '\x2', '\xC6', 
		'\x44', '\x3', '\x2', '\x2', '\x2', '\xC7', '\xC8', '\t', '\x2', '\x2', 
		'\x2', '\xC8', '\x46', '\x3', '\x2', '\x2', '\x2', '\xC9', '\xCA', '\t', 
		'\x3', '\x2', '\x2', '\xCA', 'H', '\x3', '\x2', '\x2', '\x2', '\xCB', 
		'\xD0', '\x5', 'G', '$', '\x2', '\xCC', '\xCF', '\x5', 'G', '$', '\x2', 
		'\xCD', '\xCF', '\x5', '\x45', '#', '\x2', '\xCE', '\xCC', '\x3', '\x2', 
		'\x2', '\x2', '\xCE', '\xCD', '\x3', '\x2', '\x2', '\x2', '\xCF', '\xD2', 
		'\x3', '\x2', '\x2', '\x2', '\xD0', '\xCE', '\x3', '\x2', '\x2', '\x2', 
		'\xD0', '\xD1', '\x3', '\x2', '\x2', '\x2', '\xD1', 'J', '\x3', '\x2', 
		'\x2', '\x2', '\xD2', '\xD0', '\x3', '\x2', '\x2', '\x2', '\xD3', '\xDC', 
		'\a', '\x32', '\x2', '\x2', '\xD4', '\xD8', '\t', '\x4', '\x2', '\x2', 
		'\xD5', '\xD7', '\x5', '\x45', '#', '\x2', '\xD6', '\xD5', '\x3', '\x2', 
		'\x2', '\x2', '\xD7', '\xDA', '\x3', '\x2', '\x2', '\x2', '\xD8', '\xD6', 
		'\x3', '\x2', '\x2', '\x2', '\xD8', '\xD9', '\x3', '\x2', '\x2', '\x2', 
		'\xD9', '\xDC', '\x3', '\x2', '\x2', '\x2', '\xDA', '\xD8', '\x3', '\x2', 
		'\x2', '\x2', '\xDB', '\xD3', '\x3', '\x2', '\x2', '\x2', '\xDB', '\xD4', 
		'\x3', '\x2', '\x2', '\x2', '\xDC', 'L', '\x3', '\x2', '\x2', '\x2', '\xDD', 
		'\xE1', '\a', '$', '\x2', '\x2', '\xDE', '\xE0', '\v', '\x2', '\x2', '\x2', 
		'\xDF', '\xDE', '\x3', '\x2', '\x2', '\x2', '\xE0', '\xE3', '\x3', '\x2', 
		'\x2', '\x2', '\xE1', '\xE2', '\x3', '\x2', '\x2', '\x2', '\xE1', '\xDF', 
		'\x3', '\x2', '\x2', '\x2', '\xE2', '\xE4', '\x3', '\x2', '\x2', '\x2', 
		'\xE3', '\xE1', '\x3', '\x2', '\x2', '\x2', '\xE4', '\xE5', '\a', '$', 
		'\x2', '\x2', '\xE5', 'N', '\x3', '\x2', '\x2', '\x2', '\xE6', '\xEA', 
		'\a', '%', '\x2', '\x2', '\xE7', '\xE9', '\v', '\x2', '\x2', '\x2', '\xE8', 
		'\xE7', '\x3', '\x2', '\x2', '\x2', '\xE9', '\xEC', '\x3', '\x2', '\x2', 
		'\x2', '\xEA', '\xEB', '\x3', '\x2', '\x2', '\x2', '\xEA', '\xE8', '\x3', 
		'\x2', '\x2', '\x2', '\xEB', '\xED', '\x3', '\x2', '\x2', '\x2', '\xEC', 
		'\xEA', '\x3', '\x2', '\x2', '\x2', '\xED', '\xEE', '\a', '%', '\x2', 
		'\x2', '\xEE', '\xEF', '\x3', '\x2', '\x2', '\x2', '\xEF', '\xF0', '\b', 
		'(', '\x2', '\x2', '\xF0', 'P', '\x3', '\x2', '\x2', '\x2', '\xF1', '\xF2', 
		'\t', '\x5', '\x2', '\x2', '\xF2', '\xF3', '\x3', '\x2', '\x2', '\x2', 
		'\xF3', '\xF4', '\b', ')', '\x2', '\x2', '\xF4', 'R', '\x3', '\x2', '\x2', 
		'\x2', '\xF5', '\xF6', '\a', '\xF', '\x2', '\x2', '\xF6', '\xF7', '\x3', 
		'\x2', '\x2', '\x2', '\xF7', '\xF8', '\b', '*', '\x2', '\x2', '\xF8', 
		'T', '\x3', '\x2', '\x2', '\x2', '\xF9', '\xFA', '\a', '\f', '\x2', '\x2', 
		'\xFA', '\xFB', '\x3', '\x2', '\x2', '\x2', '\xFB', '\xFC', '\b', '+', 
		'\x2', '\x2', '\xFC', 'V', '\x3', '\x2', '\x2', '\x2', '\xFD', '\xFE', 
		'\a', '\xF', '\x2', '\x2', '\xFE', '\xFF', '\a', '\f', '\x2', '\x2', '\xFF', 
		'\x100', '\x3', '\x2', '\x2', '\x2', '\x100', '\x101', '\b', ',', '\x2', 
		'\x2', '\x101', 'X', '\x3', '\x2', '\x2', '\x2', '\x102', '\x103', '\a', 
		'\v', '\x2', '\x2', '\x103', '\x104', '\x3', '\x2', '\x2', '\x2', '\x104', 
		'\x105', '\b', '-', '\x2', '\x2', '\x105', 'Z', '\x3', '\x2', '\x2', '\x2', 
		'\t', '\x2', '\xCE', '\xD0', '\xD8', '\xDB', '\xE1', '\xEA', '\x3', '\b', 
		'\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
