$path = split-path $MyInvocation.MyCommand.Path
$package = @(get-item Cascade.*.nupkg)[0].Name
set-location $path
& "$path\nuget.exe" push $package