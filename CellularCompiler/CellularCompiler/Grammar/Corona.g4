grammar Corona;

main
	: grid (states)+ initial rules
	;

grid
	: 'GRID' '{' memberDeclaration+ '}'
	;

states
	: 'STATES' ID (',' ID)* memberBlock
	;

initial
	: 'INITIAL' compoundStatement
	;

rules
	: 'RULES' '{' selectionStatement* '}'
	;

memberBlock
	: '{' memberDeclaration* '}'
	;

memberDeclaration
	: ID ':' memberValue (',' memberValue)*  ';'
	;

statement
	: selectionStatement
	| iterationStatement
	| assignmentStatement
	| compoundStatement
	| returnStatement
	;

selectionStatement
	: 'match' '(' ('state' | member) (',' member)*  ')' '{' caseStatement+ '}'
	;

iterationStatement
	: 'for' '(' initializer=expr ';' condition=expr ';' iterator=expr ')' statement
	;

assignmentStatement
	: gridPoint member? '=' (expr | STRING) ';'
	| ID = (expr | STRING) ';'
	; 

compoundStatement
	: '{' statement* '}'
	;

returnStatement
	: 'return' expr ';'
	;

caseStatement
	: '[' memberValue (',' memberValue)* ']' statement
	;

expr
	: value=INT 									# NumberExpr
	| value=ID										# IdentifierExpr
	| member 										# IdentifierExpr
	| left=expr op=operator right=expr 				# InfixExpr
	;

operator
	: '+' | '-' | '*' | '/' | '==' | '!=' | '<' | '>' | '<=' | '>='
	;

memberValue
	: arrowValue		# ArrowMemberValue
	| value=INT       # IntMemberValue
	| value=STRING    # StringMemberValue
	| value=ID        # IdentifierMemberValue
	| '_'					# DefaultMemberValue
	;

arrowValue
	: '0' '->' INT
	;

member
	: '.'ID
	;

gridPoint
	: 'grid[' expr(',' expr)* ']'
	;




fragment DIGIT :   [0-9];
fragment Nondigit :   [a-zA-Z_];

ID
	: Nondigit (Nondigit | DIGIT)*
   ;


INT
	: '0'
	| [1-9] DIGIT*
	;

STRING
	: '"' .*? '"' 
	;

COMMENT
	: '#' .*? '#' -> skip
	;

WS : [ \t\f] -> skip;
CR : '\r' -> skip;
NL : '\n' -> skip;
CRNL : '\r\n' -> skip;
TAB : '\t' -> skip;