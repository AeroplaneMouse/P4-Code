grammar Math;

main : expr EOF | EOF ;

expr 
    : Left=expr op=operator Right=expr      # InfixExpr
    | value=INT                             # NumberExpr
    ;

operator 
    : ADD
    | SUB
    | MUL
    | DIV
    ;


INT : Value=DIGIT+ ;

fragment DIGIT : [1-9] ;

ADD: '+';
SUB: '-';
MUL: '*';
DIV: '/';

Whitespace : [ \t\f] -> skip;
CR : '\r' -> skip;
NL : '\n' -> skip;
CRNL : '\r\n' -> skip;