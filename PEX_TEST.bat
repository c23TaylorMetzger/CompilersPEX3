:: Creates a Variable for the Output File
@SET file="pex_test_results.txt"

:: Erases Everything Currently In the Output File
type NUL>%file%

----------------------------------------
 TITLE
----------------------------------------
echo PEX TEST CASES (C1C Metzger and C1C Coffey) >> %file%

echo ---------------------------------------- >> %file%
echo GOOD EXAMPLES >> %file%
echo ---------------------------------------- >> %file%

echo ----------Testing Declaration Decoration for Variables---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\VariableNodeDecorationCorrect.txt >> %file%
echo. >> %file%

echo ----------Initialize an Integer Variable with a Negative Int---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\NegativeIntegerCorrect.txt >> %file%
echo. >> %file%

echo ----------Initialize a Variable with Correct Parentheses---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\ParenthesesCorrect.txt >> %file%
echo. >> %file%

echo ----------Initialize a Variable with Correct Multiplication---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\MultiplyCorrect.txt >> %file%
echo. >> %file%

echo ----------Initialize a Variable with Correct Division---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\DivideCorrect.txt >> %file%
echo. >> %file%

echo ----------Initialize a Variable with Correct Addition---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\AddCorrect.txt >> %file%
echo. >> %file%

echo ----------Initialize a Variable with Correct Subtraction---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\SubtractCorrect.txt >> %file%
echo. >> %file%


echo ---------------------------------------- >> %file%
echo BAD EXAMPLES >> %file%
echo ---------------------------------------- >> %file%

echo ----------Variable not Declared but Attempted to Initialize---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\VariableNotDeclared.txt >> %file%
echo. >> %file%

echo ----------Variable not found in Local Symbol Table---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\VariableNotInLocalSymbolTable.txt >> %file%
echo. >> %file%

echo ----------Initializing a Variable with a Negative String---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\NonIntegerNegative.txt >> %file%
echo. >> %file%

echo ----------Initializing with a String inside Parentheses---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\StringInParentheses.txt >> %file%
echo. >> %file%

echo ----------Initializing with Multiplication of Mismatched Types---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\MultiplyMismatchTypes.txt >> %file%
echo. >> %file%

echo ----------Initializing with Division of Mismatched Types---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\DivideMismatchTypes.txt >> %file%
echo. >> %file%

echo ----------Initializing with Addition of Mismatched Types---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\AddMismatchTypes.txt >> %file%
echo. >> %file%

echo ----------Initializing with Subtraction of Mismatched Types---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\SubtractMismatchTypes.txt >> %file%
echo. >> %file%

echo ----------Initializing with a Type that Does Not Exist---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex3\TypeDoesNotExist.txt >> %file%
echo. >> %file%

pause