@echo off

if [%1]==[] goto usage

dotnet new console -n "day%1"
cd day%1
dotnet add reference ../Helpers/Helpers.csproj

cd ..

goto :eof


:usage
@echo Usage: %0 day (int)