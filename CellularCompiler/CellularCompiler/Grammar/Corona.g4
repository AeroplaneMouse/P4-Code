grammar Corona;

main
	: grid (states)+ initial rules
	;

grid
	: 'GRID' memberBlock
	;

states
	: 'STATES' ID (',' ID)* memberBlock
	;

initial
	: 'INITIAL' compoundStatement
	;

// Hvis der bruges statement, vil det være muligt at have if statements og sådan, udenfor [ID]{}

rules
	: 'RULES' '{' selectionStatement* '}'
	;

memberBlock
	: '{' memberDeclaration+ '}'
	;

memberDeclaration
	: id=ID ':' memberValue (',' memberValue)*  ';'
	;

statement
	: selectionStatement
	| iterationStatement
	| assignmentStatement
	| compoundStatement
	| returnStatement
	;

selectionStatement
	: 'match' '(' ('state' | member) (',' ('state' | member))*  ')' '{' caseStatement+ '}'
	;

iterationStatement
	: 'for' '(' expr ';' expr ';' expr ')' statement
	;

assignmentStatement
	: (gridPoint member? | ID) '=' (expr | ID | STRING) ';'
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
	| value=ID 										# StringExpr 
	| value=STRING									# StringExpr
	| member 										# StringExpr
	| left=expr op=operator right=expr 		# InfixExpr
	;

operator
	: '+' | '-' | '*' | '/' | '->' | '==' | '!=' | '<' | '>' | '<=' | '>='
	;

memberValue
	: arrowValue
	| INT
	| STRING
	| ID
	| '_'
	;

arrowValue
	: INT '->' INT
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
	: '#' .*? ('#' | NL | CR | CRNL) -> skip
	;

WS : [ \t\f] -> skip;
CR : '\r' -> skip;
NL : '\n' -> skip;
CRNL : '\r\n' -> skip;