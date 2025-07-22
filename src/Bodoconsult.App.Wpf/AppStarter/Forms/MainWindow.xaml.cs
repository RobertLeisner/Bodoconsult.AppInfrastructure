// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows;
using System.Windows.Input;
using Bodoconsult.App.Wpf.Interfaces;
using Bodoconsult.App.Wpf.Utilities;

namespace Bodoconsult.App.Wpf.AppStarter.Forms
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IMainWindowViewModel _mainWindowViewModel;
        private readonly System.Windows.Threading.DispatcherTimer _dispatcherTimer;


        public MainWindow(IMainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            DataContext = _mainWindowViewModel;

            InitializeComponent();
            WindowState = WindowState.Normal;

            ResizeWindow();

            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _dispatcherTimer.Tick += dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            _dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            _dispatcherTimer.Stop();

            try
            {
                _mainWindowViewModel.CheckLogs();
            }
            catch //(Exception exception)
            {
                // Do nothing
            }


            //LogWindow.SelectionStart = LogWindow.Text.Length;
            //LogWindow.SelectionLength = 0;

            _dispatcherTimer.Start();
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
            WpfUtility.DisableMaximizeButton(this);
            WpfUtility.DisableMinimizeButton(this);
            WpfUtility.DisableCloseButton(this);
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
            _dispatcherTimer.Stop();
            _mainWindowViewModel.ShutDown();

            Close();
        }
    }
}
