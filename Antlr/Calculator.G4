grammar Calculator;

main : expr EOF | EOF ;

expr : INT operator INT ;

operator : '+' ;


INT : DIGIT+ ;

fragment DIGIT : [1-9];


