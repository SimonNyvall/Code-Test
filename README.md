# Code test [![.NET](https://github.com/SimonNyvall/Code-Test/actions/workflows/dotnet.yml/badge.svg)](https://github.com/SimonNyvall/Code-Test/actions/workflows/dotnet.yml)

## Problem
Write a program that takes one argument, reads the file name without the extension, and count the number of times the name of the file appears in the file content.

## Solution
The solution is implemented in F# and in C#.
To run the program, you need to have the .NET Core SDK installed on your machine.
Just run
```sh
dotnet run <filename>
```

## Assumptions
- The file is a text file, but could be any type of file as long as it is readable.
- The file is not too large to fit in memory.
- The file name is case insensitive. If the file name is "Test", then only "Test" should be counted, not "test" nor "TEST".
- The file must exist.

