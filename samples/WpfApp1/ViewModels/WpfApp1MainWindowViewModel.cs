// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Windows;
using Bodoconsult.App.Logging;
using Bodoconsult.App.Wpf.AppStarter.ViewModels;
using WpfApp1.Views;

namespace WpfApp1.ViewModels;

/// <summary>
/// ViewModel for MainWindow window
/// </summary>
public class WpfApp1MainWindowViewModel : MainWindowViewModel
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="listener">Current app event listener</param>
    public WpfApp1MainWindowViewModel(AppEventListener listener) : base(listener)
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
            Visibility = Visibility.Visible
        };
    }
}