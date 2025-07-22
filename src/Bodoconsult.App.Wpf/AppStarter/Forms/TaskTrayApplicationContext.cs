//// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

//using System.Windows;
//using Bodoconsult.App.Wpf.Interfaces;

//namespace Bodoconsult.App.Wpf.AppStarter.Forms;

///// <summary>
///// Application context for add the app to system tray bar
///// </summary>
//public class TaskTrayApplicationContext : ApplicationContext
//{

//    private Window _mainWindow;

//    private  IMainWindowViewModel _viewModel;

//    readonly NotifyIcon _notifyIcon = new();

//    /// <summary>
//    /// Default ctor
//    /// </summary>
//    /// <param name="viewModel">Current view model</param>
//    public TaskTrayApplicationContext(IMainWindowViewModel viewModel)
//    {
//        _viewModel = viewModel;
//        _viewModel.ApplicationContext = this;

//        _mainWindow = _viewModel.CreateWindow();

//        MainForm = _mainWindow;

//        _mainWindow.Show();

//        _notifyIcon.Icon = Icon.ExtractAssociatedIcon(Environment.ProcessPath);
//        _notifyIcon.Text = _viewModel.AppVersion;

//        var contextMenu = new ContextMenuStrip();
//        contextMenu.Items.Add("Show", null, Show);
//        contextMenu.Items.Add("Exit", null, Exit);
//        _notifyIcon.ContextMenuStrip = contextMenu;

//        _notifyIcon.Visible = true;

//    }

//    /// <summary>
//    /// Reload the window from system tray
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void Show(object sender, EventArgs e)
//    {
//        _mainWindow.WindowState = FormWindowState.Normal;
//        _mainWindow.Visible = true;
//    }

//    /// <summary>
//    /// Exit the whole app
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void Exit(object sender, EventArgs e)
//    {

//        if (System.Windows.MessageBox.Show(_viewModel.MsgExit, _viewModel.AppBuilder.AppGlobals.AppStartParameter.AppName, MessageBoxButton.YesNo,
//                MessageBoxImage.Exclamation, MessageBoxResult.No) == MessageBoxResult.No)
//        {
//            return;
//        }

//        if (System.Windows.MessageBox.Show(_viewModel.MsgExit, _viewModel.AppBuilder.AppGlobals.AppStartParameter.AppName, MessageBoxButton.YesNo,
//                MessageBoxImage.Exclamation, MessageBoxResult.No) == MessageBoxResult.No)
//        {
//            return;
//        }

//        Shutdown();
//    }

//    /// <summary>
//    /// Shut the app down
//    /// </summary>
//    public void Shutdown()
//    {
//        try
//        {
//            // We must manually tidy up and remove the icon before we exit.
//            // Otherwise it will be left behind until the user mouses over.
//            _notifyIcon.Visible = false;
//            _viewModel.ShutDown();
//            _mainWindow.Close();
//            _mainWindow.Dispose();
//            _mainWindow = null;
//            _viewModel = null;

//            ExitThread();
//        }
//        catch 
//        {
//            //
//        }

//    }
//}