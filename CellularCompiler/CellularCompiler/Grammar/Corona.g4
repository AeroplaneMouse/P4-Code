grammar Corona;

main
	: grid (states)+ initial 
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
	: 'RULES' '{' ruleStatement* '}' 
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
	| ruleStatement
	| compoundStatement
	| returnStatement
	;

selectionStatement
	: 'if' '(' expr ')' statement ('else' statement)?
	;

iterationStatement
	: 'for' '(' expr ';' expr ';' expr ')' statement
	;

assignmentStatement
	: (gridPoint member? | ID) '=' (expr | ID | STRING) ';'
	; 

ruleStatement
	: '[' ID ']' '{' statement* '}'
	;

compoundStatement
	: '{' blockItemList? '}'
	;

returnStatement
	: 'return' expr ';'
	;

blockItemList
	: blockItem
	| blockItemList blockItem
	;

blockItem
	: statement
	;

expr
	: value=INT 									# NumberExpr
	| value=ID 										# StringExpr 
	| value=STRING									# StringExpr
	| member
	| left=expr op=operator right=expr 		# InfixExpr
	;

operator
	: '+' | '-' | '*' | '/' | '->' | '==' | '!=' | '<' | '>' | '<=' | '>='
	;

memberValue
	: arrowValue
	| INT
	| STRING
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
	: '#' .*? '#' -> skip
	;

WS : [ \t\f] -> skip;
CR : '\r' -> skip;
NL : '\n' -> skip;
CRNL : '\r\n' -> skip;