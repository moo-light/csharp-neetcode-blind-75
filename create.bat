set /p "p=Enter project: "
 
dotnet new console -o %p% -f net6.0
pause