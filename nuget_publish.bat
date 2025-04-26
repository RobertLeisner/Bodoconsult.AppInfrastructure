set version=1.0.0

REdotnet nuget push Nuget\Bodoconsult.App.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push Nuget\Bodoconsult.App.WinForms.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push Nuget\Bodoconsult.App.Windows.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push Nuget\Bodoconsult.I18N.%version%.nupkg --source https://api.nuget.org/v3/index.json
pause