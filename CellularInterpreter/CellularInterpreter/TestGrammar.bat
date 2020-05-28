@ECHO off

REM Check for arguments
SET GRAMMAR_NAME=%1
SET ENTRY=%2
SET CODE=%3
GOTO CheckGrammarName


REM Ask the user to enter the grammar name
:EnterGrammarName
ECHO.
ECHO Available grammars
ECHO ******************************
cd Grammar/
dir /a /b
ECHO.
ECHO Enter grammar name
SET GRAMMAR_NAME=
SET /p GRAMMAR_NAME=Grammar name: 
cd ..


:CheckGrammarName
IF EXIST Grammar/%GRAMMAR_NAME:~0,-3%.g4 GOTO CheckEntryName
ECHO Error! Unknown grammar name: %GRAMMAR_NAME%
GOTO EnterGrammarName


REM Get program entry name
:EnterEntryName
ECHO.
SET ENTRY=
SET /p ENTRY=Enter the program entry: 

:CheckEntryName
IF "%ENTRY%"=="" GOTO EnterEntryName
GOTO CheckCodeExample

REM Get code-example
:EnterCodeExample
ECHO.
ECHO Available code examples
ECHO ******************************
cd CodeExamples/
dir /a /b
ECHO.
ECHO Enter code example name
SET CODE=
SET /p CODE=Name: 
cd ..

:CheckCodeExample
IF "%CODE%"=="" GOTO EnterCodeExample
GOTO Create

REM Create java lexer and parser files for testing
:Create
SET LASTARGS=%GRAMMAR_NAME% %ENTRY% %CODE%
ECHO.
ECHO Creating tree from grammar: "%GRAMMAR_NAME%"
ECHO Creating tree from source:  "%CODE%"
ECHO | set /p=.
java org.antlr.v4.Tool -o Testing/ Grammar/%GRAMMAR_NAME%
ECHO | set /p=.
javac Testing/%GRAMMAR_NAME:~0,-3%*.java
ECHO | set /p=.


REM Run test
cd Testing/
java -cp .;%CLASSPATH% org.antlr.v4.gui.TestRig %GRAMMAR_NAME:~0,-3% %ENTRY% -gui ../CodeExamples/%CODE%
ECHO .
cd ..

REM Cleanup
ECHO Cleanup
rmdir /S /Q Testing

SET message1="Variable %%LASTARGS%% has been set with the last arguments."
SET message2="To use it, type: %0 %%LASTARGS%%"
ECHO %message1:~1,-1%
ECHO %message2:~1,-1%
:EOF
