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
	: 'INITIAL' someState? stuff
	;

rules
	: 'RULES' 
	;

declaration
	: memberDeclaration
	;

memberDeclaration
	: id=ID ':' value=(STRING (',' (STRING)*)) ';'
	;

statements
	: statements* statement ';' 
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












INT
	: 0
	| [1-9] [0-9]*
	;

STRING
	: [a-z] [A-Z] [0-9] 'Any permutation of this'
	;

COMMENT
	: '#' .*? '#' -> skip
	;

WS : [ \t\f] -> skip;
CR : '\r' -> skip;
NL : '\n' -> skip;
CRNL : '\r\n' -> skip;