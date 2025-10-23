// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows;
using System.Windows.Input;
using Bodoconsult.App.Wpf.Helpers;
using Bodoconsult.App.Wpf.Interfaces;

namespace WpfApp1.Views;

/// <summary>
/// Code behind for main window
/// </summary>
public partial class MainWindow : Window
{

    private readonly IMainWindowViewModel _mainWindowViewModel;


    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="mainWindowViewModel">View model</param>
    public MainWindow(IMainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        DataContext = _mainWindowViewModel;

        InitializeComponent();

        ResizeWindow();

        _mainWindowViewModel.StartEventListener();
    }



    private void ResizeWindow()
    {
        _mainWindowViewModel.Width = RenderSize.Width;
        _mainWindowViewModel.Height = Header.RenderSize.Height;
    }

    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        ResizeWindow();
    }


    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        WpfHelper.DisableMaximizeButton(this);
        WpfHelper.DisableCloseButton(this);
    }

    private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
    {

        // Check if STRG+C is pressed: if no break here else shutdown
        if (e.Key != Key.C && Keyboard.Modifiers == ModifierKeys.Control)
        {
            return;
        }

        //if (MessageBox.Show(_mainWindowViewModel.MsgExit, _mainWindowViewModel.AppName, MessageBoxButton.YesNo,
        //        MessageBoxImage.Stop, MessageBoxResult.No) == MessageBoxResult.No)
        //{
        //    return;
        //}
        _mainWindowViewModel.ShutDown();

        Close();
    }


}