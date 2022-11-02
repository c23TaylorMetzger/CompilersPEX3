:: Creates a Variable for the Output File
@SET file="pex_test_results.txt"

:: Erases Everything Currently In the Output File
type NUL>%file%

----------------------------------------
 TITLE
----------------------------------------
echo PEX TEST CASES (C1C Metzger) >> %file%

echo ---------------------------------------- >> %file%
echo GOOD EXAMPLES >> %file%
echo ---------------------------------------- >> %file%

echo ----------Testing Declaration Statements---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\declaration_correct.txt >> %file%
echo. >> %file%

echo ----------Testing Function Call Statements---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\function_call_correct.txt >> %file%
echo. >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\function_call_correct2.txt >> %file%
echo. >> %file%

echo ----------Testing Assignment Statements---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_simple_correct.txt >> %file%
echo. >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_advanced_correct.txt >> %file%
echo. >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_add_subtract_correct.txt >> %file%
echo. >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_mult_div_correct.txt >> %file%
echo. >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_parenthesis_correct.txt >> %file%
echo. >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_complex_negative_correct.txt >> %file%
echo. >> %file%

echo ----------Testing Branching Statements---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\branching_correct.txt >> %file%
echo. >> %file%

echo ----------Testing Looping Statements---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\iteration_correct.txt >> %file%
echo. >> %file%

echo ----------Testing Declarations of Helper Functions---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\helper_declare_correct.txt >> %file%
echo. >> %file%

echo ----------Testing Declarations of the Main Function---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\main_declare_correct.txt >> %file%
echo. >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\main_declare_correct2.txt >> %file%
echo. >> %file%

echo ---------------------------------------- >> %file%
echo BAD EXAMPLES >> %file%
echo ---------------------------------------- >> %file%

echo ----------Running Incorrect Declaratin Statement---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\declaration_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect Simple Assignment---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_simple_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect Advanced Assignment---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_advanced_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect Addition Subtraction Assignment---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_add_subtract_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect Multiplication and Division Assignment---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_mult_div_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect Parenthesis Assignment---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_parenthesis_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect Complex Negative Assignment---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\assign_complex_negative_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect Function Call---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\function_call_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect Branch Structure---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\branching_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect While Loop Structure---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\iteration_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect Helper Function Declare---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\helper_declare_incorrect.txt >> %file%
echo. >> %file%

echo ----------Running Incorrect Main Function Declare---------- >> %file%
bin\Debug\ConsoleApplication.exe testcases\pex2\main_declare_incorrect.txt >> %file%
echo. >> %file%

pause