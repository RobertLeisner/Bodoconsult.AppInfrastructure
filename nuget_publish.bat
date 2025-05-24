set version=1.0.3

dotnet nuget push nuget\Bodoconsult.App.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push nuget\Bodoconsult.App.WinForms.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push nuget\Bodoconsult.App.BackgroundService.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push nuget\Bodoconsult.App.GrpcBackgroundService.%version%.nupkg --source https://api.nuget.org/v3/index.json

REM dotnet nuget push Nuget\Bodoconsult.App.Windows.%version%.nupkg --source https://api.nuget.org/v3/index.json
REM dotnet nuget push Nuget\Bodoconsult.I18N.%version%.nupkg --source https://api.nuget.org/v3/index.json
pause