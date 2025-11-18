// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Avalonia.Controls;
using AvaloniaApp1.Views;
using Bodoconsult.App.Avalonia.AppStarter.ViewModels;
using Bodoconsult.App.Logging;

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
    public AvaloniaApp1MainWindowViewModel(AppEventListener listener) : base(listener)
    { }

    /// <summary>
    /// Create the main form of the application
    /// </summary>
    /// <returns></returns>
    public override Window CreateWindow()
    {
        return new MainWindow(this)
        {
            WindowState = WindowState.Normal,
            IsVisible = true
        };
    }
}