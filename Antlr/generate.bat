@echo off

set NAME=Calculator
set START_METHOD=main
set CODE_FILE=calSource


@rem if not %*==nil set NAME=%*

@rem Remove old target folder, quietly
@rem rmdir /S /Q target

@rem Generate lexer and parser
echo | set /p=.
java -cp antlr-4.7.2-complete.jar org.antlr.v4.Tool -o target/ -listener -visitor %NAME%.g4
echo | set /p=.

@rem Compile lexer and parser
echo | set /p=.
@rem echo  set /p=Compiling...   
javac -cp antlr-4.7.2-complete.jar target/*.java
echo | set /p=.

@rem Compile source code
echo .
@rem echo  set /p=Compiling the actual program...  
java -cp target/.;antlr-4.7.2-complete.jar org.antlr.v4.gui.TestRig %NAME% %START_METHOD% -gui -tokens %CODE_FILE%.txt
echo Done

pause