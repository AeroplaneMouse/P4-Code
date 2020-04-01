@ECHO off

@REM Default grammar name and start method.
set NAME=Calculator
set START_METHOD=main
set PROGRAM_NAME=%0

@REM ***********************************************
@REM Check commandline arguments
:Loop
IF "%1"=="" GOTO Continue
	IF "%1"=="-n" GOTO Name
	IF "%1"=="-s" GOTO StartMethod
	ECHO ERROR! Invalid argument: %1
	GOTO InvalidUsage

:Name
IF "%2"=="" GOTO NameElse
	SET NAME=%2
	GOTO Next
:NameElse
ECHO ERROR! Grammar name cannot be empty
GOTO InvalidUsage

:StartMethod
IF "%2"=="" GOTO StartElse
	SET START_METHOD=%2
	GOTO Next
:StartElse
ECHO Start method name cannot be empty
GOTO InvalidUsage

:Next
SHIFT
SHIFT
GOTO Loop

:InvalidUsage
ECHO %PROGRAM_NAME% [options]
ECHO.
ECHO Options:
ECHO -n [NAME]    - Name of the grammar file without extension. Default is: %NAME%
ECHO -s [NAME]    - Name of the starting method. Default is: %START_METHOD%
ECHO.
GOTO EOF


@REM ***********************************************
:Continue
ECHO Using these as parameters
ECHO Name:          %NAME%
ECHO Start method:  %START_METHOD%
ECHO.
@REM if not %*==nil set NAME=%*

@REM Remove old target folder, quietly
@REM rmdir /S /Q target

@REM Generate lexer and parser
ECHO | set /p=.
java -cp antlr-4.7.2-complete.jar org.antlr.v4.Tool -o dist-grammar/ -listener -visitor src-grammar/%NAME%.g4
ECHO | set /p=.

@REM Compile lexer and parser
ECHO | set /p=.
@REM ECHO  set /p=Compiling...   
javac -cp antlr-4.7.2-complete.jar dist-grammar/*.java
ECHO | set /p=.

@REM Compile source code
ECHO .
@REM ECHO  set /p=Compiling the actual program...  
java -cp dist-grammar/.;antlr-4.7.2-complete.jar org.antlr.v4.gui.TestRig %NAME% %START_METHOD% -gui -tokens src-input/%NAME%-input*
ECHO Done


@REM ***********************************************
:EOF
@REM Pause at the end. This stoppes the CMD from dissapering, if not run in an existing open CMD.
pause