set version=1.0.6
dotnet nuget push packages\Bodoconsult.App.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push packages\Bodoconsult.App.%version%.snupkg --source https://api.nuget.org/v3/index.json

dotnet nuget push packages\Bodoconsult.App.WinForms.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push packages\Bodoconsult.App.WinForms.%version%.snupkg --source https://api.nuget.org/v3/index.json

dotnet nuget push packages\Bodoconsult.App.BackgroundService.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push packages\Bodoconsult.App.BackgroundService.%version%.snupkg --source https://api.nuget.org/v3/index.json

dotnet nuget push packages\Bodoconsult.App.GrpcBackgroundService.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push packages\Bodoconsult.App.GrpcBackgroundService.%version%.snupkg --source https://api.nuget.org/v3/index.json

dotnet nuget push packages\Bodoconsult.App.Windows.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push packages\Bodoconsult.App.Windows.%version%.snupkg --source https://api.nuget.org/v3/index.json

dotnet nuget push packages\Bodoconsult.I18N.%version%.nupkg --source https://api.nuget.org/v3/index.json
dotnet nuget push packages\Bodoconsult.I18N.%version%.snupkg --source https://api.nuget.org/v3/index.json
pause