grammar Corona;

main
	: setting states+ initial rules
	;

setting
	: 'GRID' INT'x'INT';'
	;

states
	:
	;

initial
	: 'INITIAL' someState? '{' stuff '}'
	;

rules
	: 'RULES{'  '}'
	;

ifStatement
	: 'if(' expr '){' statements '}' 
		('else if(' expr '){' statements '}')* 
		('else{' statement '}')
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