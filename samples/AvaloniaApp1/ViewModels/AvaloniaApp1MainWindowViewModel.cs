// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Avalonia.Controls;
using AvaloniaApp1.Views;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Avalonia.AppStarter.ViewModels;

namespace AvaloniaApp1.ViewModels;

/// <summary>
/// ViewModel for MainWindow window
/// </summary>
public class AvaloniaApp1MainWindowViewModel : MainWindowViewModel
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="listener">Current app event listener</param>
    /// <param name="translationService">Current translation service</param>
    public AvaloniaApp1MainWindowViewModel(IAppEventListener listener, II18N translationService) : base(listener, translationService)
    { }

    /// <summary>
    /// Create the main form of the application
    /// </summary>
    /// <returns></returns>
    public override Window CreateWindow()
    {
        var vm = new MainWindow
        {
            IsVisible = true
        };
        vm.InjectViewModel(this);
        return vm;
    }
}