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
	: 'INITIAL' ID '{'  statements  '}'
	;

rules
	: 'RULES' '{'  '}' 
	;

declaration
	: memberDeclaration
	;

memberDeclaration
	: id=ID ':' STRING (',' STRING)* ';'
	;

statements
	: statement statements* 
	;

statement
	: selectionStatement
	| iterationStatement
	| assignmentStatement
	| ruleStatement
	| compoundStatement
	;

selectionStatement
	: 'if' '(' expr ')' statement ('else' statement)?
	;

iterationStatement
	: 'for' '(' expr ';' expr ';' expr ')' statement
	;

assignmentStatement
	: ID ('[' expr ',' expr']')? ('.' ID)? '=' (expr | ID | STRING) ';'
	;

ruleStatement
	: '[' ID ']' '{' statements '}'
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
	: INT
	| expr operator expr
	;

operator
	: '+' | '-' | '*' | '/' | '->'
	;









ID
	: Nondigit (Nondigit | DIGIT)*
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