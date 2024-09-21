@echo off
set /p "p=Enter project: "
 
dotnet new console -o %p% -f net6.0
dotnet sln add %p%
cd %p%
dotnet new sln
dotnet sln add %p%.csproj
start %p%.sln

exit