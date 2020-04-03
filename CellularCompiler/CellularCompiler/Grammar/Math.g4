grammar Math;

main : expr EOF | EOF ;

expr 
    : Left=expr op=operator Right=expr      # InfixExpr
    | value=INT                             # NumberExpr
    ;

operator 
    : '+'
    | '-'
    | '*'
    | '/'
    ;


INT : Value= '0' | [1-9] [0-9]* ;

// fragment DIGIT : [1-9] [0-9]* ; 

Whitespace : [ \t\f] -> skip;
CR : '\r' -> skip;
NL : '\n' -> skip;
CRNL : '\r\n' -> skip;