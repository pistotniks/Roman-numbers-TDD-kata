# Roman-numbers-TDD-kata

To run the tests with Cake without bootstrapper, run:

PS C:\git\Roman-numbers-TDD-kata>dotnet cake

OR

PS C:\git\Roman-numbers-TDD-kata> .\go.cmd

OR (if you run it in a command prompt and not powershell shell)

C:\git\Roman-numbers-TDD-kata>go

To run the tests with a bootstrapper, which means you can use any script, run:

[OPTIONAL-FIRST TIME ONLY]
PS C:\git\Roman-numbers-TDD-kata>Invoke-WebRequest https://cakebuild.net/download/bootstrapper/dotnet-tool/windows -OutFile build.ps1

PS C:\git\Roman-numbers-TDD-kata> .\build.ps1

To execute specific target, run:

PS C:\git\Roman-numbers-TDD-kata> dotnet cake --target=Build

OR

PS C:\git\Roman-numbers-TDD-kata> .\build.ps1 --target=Build

OR (if you run it in a command prompt and not powershell shell)

C:\git\Roman-numbers-TDD-kata>go Build
