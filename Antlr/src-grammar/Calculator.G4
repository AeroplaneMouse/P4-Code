grammar Calculator;

main : expr EOF | EOF ;

expr : INT operator INT ;

operator : '+' ;


INT : DIGIT+ ;

fragment DIGIT : [1-9] ;

Whitespace : [ \t\f] -> skip;
CR : '\r' -> skip;
NL : '\n' -> skip;
CRNL : '\r\n' -> skip;