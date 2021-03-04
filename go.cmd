@echo off

dotnet tool restore

IF "%1" == "" (
    dotnet cake
) ELSE (
    dotnet cake --target=%*
)

if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }


