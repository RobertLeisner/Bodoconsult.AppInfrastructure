set version=1.0.2

dotnet nuget push Nuget\Bodoconsult.App.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push Nuget\Bodoconsult.App.WinForms.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push Nuget\Bodoconsult.App.BackgroundService.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push Nuget\Bodoconsult.App.GrpcBackgroundService.%version%.nupkg --source https://api.nuget.org/v3/index.json

REM dotnet nuget push Nuget\Bodoconsult.App.Windows.%version%.nupkg --source https://api.nuget.org/v3/index.json
REM dotnet nuget push Nuget\Bodoconsult.I18N.%version%.nupkg --source https://api.nuget.org/v3/index.json
pause