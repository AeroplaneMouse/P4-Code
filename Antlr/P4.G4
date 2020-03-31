grammar P4;

program
    :   initialSetup? EOF
    ;

initialSetup
    :   setup
    |   initialSetup setup
    ;

setup
    :   settings
    |   functiondefinition
    |   function
    |   ruledefinition
    |   decl
    ;

settings
    :   'grid:' Int ',' Int 'states:' statelist ';'
    ;

statelist
    :   Identifier ',' statelist
    |   Identifier
    ;
    
function
    :   functiondefinition function
    ;

statement
    :   assignment
    |   ifstatement
    |   forstatement
    |   setstatement
    |   whilestatement
    |   functioncall
    ;

assignment
    :   Identifier '=' expr
    |   Identifier '=' Int
    ;

statlist
    :   statement statlist
    |   /* Empty */
    ;

ruledefinition
    :   'RULE' Identifier LCurly statlist RCurly
    ;

// This needs a boolean expression. Same for while
ifstatement
    :   'if' LParen expr RParen LCurly statlist RCurly
    ;

forstatement
    :   'for' LParen assignment ';' expr ';' statement RParen LCurly statlist RCurly
    ;

whilestatement
    :   'while' LParen expr RParen LCurly statlist RCurly
    ;

setstatement
    :   'set' LParen setter RParen
    ;

setter
    :   Int ',' Int ',' Identifier
    |   Identifier ',' Identifier ',' Identifier
    ;

decl
    :   'int' Identifier '=' expr
    ;

expr
    :   operand operator operand
    |   expr operator operand
    |   operand operator expr
    |   expr operator expr
    ;

operator
    :   Less
    |   Greater
    |   LessEqual
    |   GreaterEqual
    |   Equal
    |   NotEqual
    |   Plus
    |   Minus
    |   Mult
    |   Div
    |   Mod
    |   Power
    ;

operand
    :   Int
    |   Identifier
    ;

functiondefinition
    :   type function Identifier LParen typeparameterlist RParen LCurly statlist RCurly
    |   type function Identifier LParen RParen LCurly statlist RCurly
    |   Void function Identifier LParen typeparameterlist RParen LCurly statlist RCurly
    |   Void function Identifier LParen RParen LCurly statlist RCurly
    ;

typeparameterlist
    :   type parameter ',' typeparameterlist
    |   type parameter
    ;

functioncall
    :   Identifier LParen paralist RParen
    |   Identifier LParen RParen
    ;

paralist
    :   parameter ',' paralist
    |   parameter
    ;

parameter
    :   Identifier
    |   Int
    ;

keywords
    :   Void
    ;

Int : Digit+;
Float : Digit+ '.';
type
    :   Int
    ;

Identifier
    :   IdentifierNondigit
        (IdentifierNondigit | Digit)*
    ;

fragment IdentifierNondigit :   Nondigit;

fragment Digit :   [0-9];
fragment Nondigit :   [a-zA-Z_];

Less : '<';
Greater : '>';
LessEqual : '<=';
GreaterEqual : '>=';
Equal : '==';
NotEqual : '!=';
Plus : '+';
Minus : '-';
Mult : '*';
Div : '/';
Mod : '%';
Power : '^';

LParen : '(';
RParen : ')';
LCurly : '{';
RCurly : '}';

Void : 'void';

Whitespace : [ \t\f] -> skip;

CR : '\r' -> skip;
NL : '\n' -> skip;
CRNL : '\r\n' -> skip;