@echo off

if [%1]==[] goto usage

dotnet new console -n "day%1"
cd day%1
dotnet add reference ../Helpers/Helpers.csproj

cd ..

dotnet sln add day%1/day%1.csproj


goto :eof


:usage
@echo Usage: %0 day (int)