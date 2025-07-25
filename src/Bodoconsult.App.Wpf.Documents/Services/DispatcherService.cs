using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;

namespace Bodoconsult.Wpf.Documents.Services
{
    /// <summary>
    /// Service class to start and quit an WPF application if there no one started already
    /// For usage of WPF features in non-WPF application
    /// </summary>
    public static class DispatcherService
    {


        /// <summary>
        /// Contains the current WPF application
        /// </summary>
        public static Application CurrentApplication { get; set; }

        /// <summary>
        /// Dispose the dispatcher to close the application finally (only needed in NON-WPF-Applications)
        /// </summary>
        public static void DisposeDispatcher()
        {
            CurrentApplication.Dispatcher.InvokeShutdown();
            Application.Current.Dispatcher.InvokeShutdown();

            //for (var i = TempFiles.Count - 1; i >= 0; i--)
            //{
            //    var fileName = TempFiles[i];
            //    if (File.Exists(fileName)) File.Delete(fileName);
            //}
        }

        /// <summary>
        /// Open the dispatcher  (only needed in NON-WPF-Applications)
        /// </summary>
        public static void OpenDispatcher()
        {
            TempFiles = new List<string>();

            if (Application.Current != null) return;
            var thread = new Thread(CreateApp);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            
            Thread.Sleep(300);
        }

        private static void CreateApp()
        {
            if (Application.Current != null)
            {
                CurrentApplication = Application.Current;
                return;
            }

            CurrentApplication = new Application { ShutdownMode = ShutdownMode.OnExplicitShutdown };
            CurrentApplication.Run();
        }

        /// <summary>
        /// Keeps paths to temporary files to be deleted on shutdown of the application
        /// </summary>
        public static IList<string> TempFiles { get; set; }

    }
}
