@ECHO off

REM Check for arguments
SET GRAMMAR_NAME=%1
GOTO CheckGrammarName

REM Ask the user to enter the grammar name
:EnterGrammarName
ECHO.
ECHO Available grammars
ECHO ******************************
dir Grammar /a /b
ECHO.
ECHO Enter grammar name without .g4

SET GRAMMAR_NAME=
SET /p GRAMMAR_NAME=Grammar name:

:CheckGrammarName
IF EXIST Grammar/%GRAMMAR_NAME%.g4 GOTO Create
ECHO Error! Unknown grammar name: %GRAMMAR_NAME%
GOTO EnterGrammarName

REM Create lexer and parser files
:Create
ECHO.
ECHO Creating lexer and parser based on grammar: %GRAMMAR_NAME%
ECHO Placing files in: Parser/%GRAMMAR_NAME%/
java org.antlr.v4.Tool -Dlanguage=CSharp -visitor -o Parser/%GRAMMAR_NAME%/ Grammar/%GRAMMAR_NAME%.g4
ECHO Done

PAUSE