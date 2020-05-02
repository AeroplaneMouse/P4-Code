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
	: 'RULES' '{' ruleStatement* '}'
	;

memberBlock
	: '{' memberDeclaration* '}'
	;

memberDeclaration
	: ID ':' memberValue (',' memberValue)*  ';'
	;

statement
	: iterationStatement
	| assignmentStatement
	| compoundStatement
	| returnStatement
	;

ruleStatement
	: 'match' '(' ('state' | member) (',' member)*  ')' '{' caseStatement+ '}'
	;

iterationStatement
	: 'for' '(' initializer=expr ';' condition=expr ';' iterator=expr ')' statement
	;

assignmentStatement
	: gridPoint member? '=' ID ';' 	# GridAssignStatement
	| ID '=' (expr | STRING) ';'   	# IdentifierAssignStatement
	; 

compoundStatement
	: '{' statement* '}'
	;

returnStatement
	: 'return' ID ';'
	;

caseStatement
	: '[' ID (',' ID)* ']' statement
	;

expr
	: value=INT 									# NumberExpr
	| value=ID										# IdentifierExpr
	| member 										# IdentifierExpr
	| left=expr op=operator right=expr 				# InfixExpr
	| left=expr op=comparisonOperator right=expr	# ComparisonExpr
	;

operator
	: '+' | '-' | '*' | '/'
	;

comparisonOperator
	: '==' | '!=' | '<' | '>' | '<=' | '>='
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