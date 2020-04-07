grammar Corona;

main
	: grid (states)+ initial rules
	;

grid
	: 'GRID' INT '@' INT';'
	;

states
	: 'STATES' ID (',' ID)* '{' (declaration)+ '}'
	;

initial
	: 'INITIAL' ID '{'  statements  '}'
	;

// Hvis der bruges statement, vil det være muligt at have if statements og sådan, udenfor [ID]{}
rules
	: 'RULES' '{' ruleStatement* '}' 
	;

declaration
	: memberDeclaration
	;

memberDeclaration
	: id=ID ':' STRING (',' STRING)* ';'
	;

statements
	: statement*
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
	: ID ('[' expr ',' expr']')? ('.' ID)? '=' (expr | ID | STRING) ';'
	;

ruleStatement
	: '[' ID ']' '{' statements '}'
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
	| declaration
	;

expr
	: INT
	| ID
	| STRING
	| expr operator expr
	;

operator
	: '+' | '-' | '*' | '/' | '->' | '==' | '!=' | '<' | '>' | '<=' | '>='
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