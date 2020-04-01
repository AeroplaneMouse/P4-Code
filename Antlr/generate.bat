@ECHO off

@REM Default grammar name and start method.
SET NAME=Calculator
SET START_METHOD=main

@REM Setting default parameters
SET PROGRAM_NAME=%0
SET SOURCE_GRAMMAR_DIR=src-grammar
SET SOURCE_INPUT_DIR=src-input
SET DIST_GRAMMAR_DIR=dist-grammar
SET ANTLR_ARGS=-listener -visitor
SET GRUN_ARGS=-gui
SET DELETE_DIST_GRAMMAR_DIR=false

@REM ***********************************************
@REM Check commandline arguments
:Loop
IF "%1"=="" GOTO Continue
	IF "%1"=="-n" GOTO Name
	IF "%1"=="-s" GOTO StartMethod
	IF "%1"=="--remove-dist-folder" GOTO RemoveDist
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


:RemoveDist
SET DELETE_DIST_GRAMMAR_DIR=true
SHIFT
GOTO Loop


:Next
SHIFT
SHIFT
GOTO Loop

:InvalidUsage
ECHO %PROGRAM_NAME% [options]
ECHO.
ECHO Options:
ECHO -n [NAME]             - Name of the grammar file without extension. Default is: %NAME%
ECHO -s [NAME]             - Name of the starting method. Default is: %START_METHOD%
ECHO --remove-dist-folder  - Deletes the "%DIST_GRAMMAR_DIR%" folder before generating lexer and parser.
ECHO.
GOTO EOF


@REM ***********************************************
:Continue
ECHO Using these as parameters
ECHO Grammer name: %NAME%
ECHO Start method: %START_METHOD%
ECHO Delete dist:  %DELETE_DIST_GRAMMAR_DIR%
ECHO.

SET GRUN_ARGS=%NAME% %START_METHOD% %GRUN_ARGS%

IF %DELETE_DIST_GRAMMAR_DIR%==false GOTO SkipDelete
	@REM Remove old target folder, quietly
	rmdir /S /Q %DIST_GRAMMAR_DIR%
:SkipDelete

@REM Generate lexer and parser
ECHO | set /p=.
java -cp antlr-4.7.2-complete.jar org.antlr.v4.Tool -o %DIST_GRAMMAR_DIR%/ %ANTLR_ARGS% %SOURCE_GRAMMAR_DIR%/%NAME%.g4
ECHO | set /p=.

@REM Compile lexer and parser
ECHO | set /p=.
@REM ECHO  set /p=Compiling...   
javac -cp antlr-4.7.2-complete.jar %DIST_GRAMMAR_DIR%/*.java
ECHO | set /p=.

@REM Compile source code
ECHO .
@REM ECHO  set /p=Compiling the actual program...  
java -cp %DIST_GRAMMAR_DIR%/.;antlr-4.7.2-complete.jar org.antlr.v4.gui.TestRig %GRUN_ARGS% %SOURCE_INPUT_DIR%/%NAME%-input*
ECHO Done


@REM ***********************************************
:EOF
@REM Pause at the end. This stoppes the CMD from dissapering, if not run in an existing open CMD.
pause