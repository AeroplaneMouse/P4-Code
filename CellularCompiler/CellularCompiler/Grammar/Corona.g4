grammar Corona;

main
	: grid (states)+ initial rules
	;

grid
	: 'GRID' '{' gridDeclaration gridDeclaration '}'
	;

states
	: 'STATES' ID (',' ID)* '{' memberDeclaration* '}'
	;

initial
	: 'INITIAL' compoundStatement
	;

rules
	: 'RULES' compoundStatement
	;

memberDeclaration
	: ID ':' memberValue (',' memberValue)*  ';'
	;

gridDeclaration
	: ID ':' INT ';'
	;

statement
	: iterationStatement
	| assignmentStatement
	| compoundStatement
	| returnStatement
	| matchStatement
	;

matchStatement
	: 'match' '(' matchElement (',' matchElement)* ')' '{' caseStatement+ '}'
	;

matchElement
	: member
	| gridPoint
	| expr 
	;

iterationStatement
	//: 'for' '(' initializer=expr ';' condition=expr ';' iterator=expr ')' statement
	: 'while' '(' conditioner=expr ')' statement
	;

assignmentStatement
	: gridPoint '=' ID ';' 	# GridAssignStatement
	| identifierValue '=' (expr | STRING) ';'   	# IdentifierAssignStatement
	; 

compoundStatement
	: '{' statement* '}'
	;

returnStatement
	: 'return' identifierValue ';'
	;

caseStatement
	: '[' caseValue (',' caseValue)* ']' statement
	;

caseValue
	: memberValue     # MemberCaseValue
	| identifierValue	# IdentifierCaseValue
	| DEFAULT     		# DefaultCaseValue
	;

expr
	: intValue 											   # NumberExpr
	| identifierValue										# IdentifierExpr
	| '.' identifierValue                        # IdentifierExpr
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
	: arrowValue
	| intValue
	| stringValue
	;

member
	: '.'ID
	| '.state'
	;

gridPoint
	: 'grid[' expr(',' expr)* ']' member?
	;

arrowValue
	: INT '->' INT
	;

intValue
	: INT
	| '-'INT
	;

stringValue
	: STRING
	;

identifierValue
	: ID
	;





fragment DIGIT :   [0-9];
fragment Nondigit :   [a-zA-Z_];

DEFAULT
	: '_'
	;

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