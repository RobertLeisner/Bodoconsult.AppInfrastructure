// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Bodoconsult.App.Avalonia.AppStarter.ViewModels;
using Bodoconsult.App.Avalonia.Interfaces;

namespace AvaloniaApp1.Views;

public partial class MainWindow : Window
{
    public IMainWindowViewModel MainWindowViewModel { get; }

    /// <summary>
    /// Default ctor
    /// </summary>
    public MainWindow()
    {
        MainWindowViewModel = new MainWindowViewModel();
        DataContext = MainWindowViewModel;

        InitializeComponent();

        ResizeWindow();

        MainWindowViewModel.StartEventListener();
    }

    /// <summary>
    /// Ctor providing a customized view model
    /// </summary>
    /// <param name="mainWindowViewModel">View model</param>
    public MainWindow(IMainWindowViewModel mainWindowViewModel)
    {
        MainWindowViewModel = mainWindowViewModel;
        DataContext = MainWindowViewModel;

        InitializeComponent();

        ResizeWindow();

        MainWindowViewModel.StartEventListener();
    }



    private void ResizeWindow()
    {
        //MainWindowViewModel.Width = RenderSize.Width;
        //MainWindowViewModel.Height = Header.RenderSize.Height;
    }

    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        ResizeWindow();
    }


    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        //WpfHelper.DisableMaximizeButton(this);
        //WpfHelper.DisableCloseButton(this);
    }

    private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
    {

        //// Check if STRG+C is pressed: if no break here else shutdown
        //if (e.Key != Key.C && Keyboard.Modifiers == ModifierKeys.Control)
        //{
        //    return;
        //}

        ////if (MessageBox.Show(_mainWindowViewModel.MsgExit, _mainWindowViewModel.AppName, MessageBoxButton.YesNo,
        ////        MessageBoxImage.Stop, MessageBoxResult.No) == MessageBoxResult.No)
        ////{
        ////    return;
        ////}
        //MainWindowViewModel.ShutDown();

        //Close();
    }
}