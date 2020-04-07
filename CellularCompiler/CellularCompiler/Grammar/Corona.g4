grammar Corona;

main
	: grid (states)+ initial rules
	;

grid
	: 'GRID' INT 'x' INT';'
	;

states
	: 'STATES' ID (',' ID)* '{' (declaration)+ '}'
	;

initial
	: 'INITIAL' //someState? stuff
	;

rules
	: 'RULES' 
	;

declaration
	: memberDeclaration
	;

memberDeclaration
	: id=ID ':' value=.*? ';'
	;

statements
	: statement ';' statements* 
	;

statement
	: selectionStatement
	| iterationStatement
	| assignmentStatement
	;

selectionStatement
	: 'if' '(' expr ')' statement ('else' statement)?
	;

iterationStatement
	: 'for' '(' expr ';' expr ';' expr ')' statement
	;

assignmentStatement
	: ID '=' expr
	;

compoundStatement
	: '{' blockItemList? '}'
	;

blockItemList
	: blockItem
	| blockItemList blockItem
	;

blockItem
	: statement
	| declaration
	;

expr
	: 
	;










ID
	: Nondigit STRING
   ;


fragment DIGIT :   [0-9];
fragment Nondigit :   [a-zA-Z_];

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