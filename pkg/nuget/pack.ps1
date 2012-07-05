$path = split-path $MyInvocation.MyCommand.Path
set-location $path
remove-item *.old
remove-item *.nupkg
& "$path\nuget.exe" pack "../../src/Cascade/Cascade/Cascade.csproj" -build