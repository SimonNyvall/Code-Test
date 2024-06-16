$currentPath = Get-Location

# Test the CS code
Set-Location -Path $currentPath/Csharp/tests

Write-Host "Running charp tests..."
dotnet test

# Run the CS code
Set-Location -Path $currentPath/Csharp/src

dotnet run ../../test.txt


# Test the FS code
Set-Location -Path $currentPath/Fsharp/tests

Write-Host "Running fsharp tests..."
dotnet test

# Run the FS code
Set-Location -Path $currentPath/Fsharp/src

dotnet run ../../test.txt

# Clean up
Set-Location -Path $currentPath

