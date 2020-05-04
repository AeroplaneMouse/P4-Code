grammar Corona;

main
	: grid (states)+ initial rules
	;

grid
	: 'GRID' '{' gridDeclaration+ '}'
	;

states
	: 'STATES' ID (',' ID)* '{' memberDeclaration* '}'
	;

initial
	: 'INITIAL' compoundStatement
	;

rules
	: 'RULES' '{' ruleStatement* '}'
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
	| ruleStatement
	;

ruleStatement
	: 'match' '(' matchElement+ ')' '{' caseStatement+ '}'
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
	: '[' value=caseValue+ ']' statement
	;

caseValue
	: memberValue # MemberCaseValue
	| ID          # IdentifierCaseValue
	| DEFAULT     # DefaultCaseValue
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
	;

member
	: '.'ID
	| '.state'
	;

gridPoint
	: 'grid[' expr(',' expr)* ']'
	;

arrowValue
	: INT '->' INT
	;

matchElement
	: gridPoint? member
	| expr 
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

DEFAULT
	: '_'
	;

COMMENT
	: '#' .*? '#' -> skip
	;

WS : [ \t\f] -> skip;
CR : '\r' -> skip;
NL : '\n' -> skip;
CRNL : '\r\n' -> skip;
TAB : '\t' -> skip;