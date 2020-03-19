import files.*;

%%

%public

%class search
%line
%column

%char
%state COMMENT
%unicode

%debug

eol=\r|\n|\r\n
Blank=[ \t\f]
Digits=[0-9]+
Identifier=[a-zA-Z][a-zA-Z0-9_']+

%%

<YYINITIAL> {
{Blank}+    { }
{eol}       { }
"="         {   return (new Yytoken(0,yytext(),yyline,yychar,yychar+1)); }
"+"         {   return (new Yytoken(1,yytext(),yyline,yychar,yychar+1)); }
"-"         {   return (new Yytoken(2,yytext(),yyline,yychar,yychar+1)); }
float       {   String str = yytext().substring(0,yytext().length());
                return (new Yytoken(3,str,yyline,yychar,yychar + str.length()));
            }
int         {   String str = yytext().substring(0,yytext().length());
                return (new Yytoken(4,str,yyline,yychar,yychar + str.length()));
            }
pointer     {   String str = yytext().substring(0,yytext().length());
                return (new Yytoken(5,str,yyline,yychar,yychar + str.length()));
            }
{Identifier}   {   String str = yytext().substring(0,yytext().length());
                return (new Yytoken(6,str,yyline,yychar,yychar + str.length()));
            }
{Digits}|({Digits}"."{Digits}) {   String str = yytext().substring(0,yytext().length());
                return (new Yytoken(7,str,yyline,yychar,yychar + str.length()));
            }


}