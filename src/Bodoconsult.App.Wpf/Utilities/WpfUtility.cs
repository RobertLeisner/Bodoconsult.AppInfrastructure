using Bodoconsult.App.Wpf.Models;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Bodoconsult.App.Wpf.Utilities
{
    /// <summary>
    /// General utilities for WPF
    /// </summary>
    public static class WpfUtility
    {
        // https://learn.microsoft.com/en-us/answers/questions/746124/how-to-disable-and-enable-window-close-button-(x)

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);



        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern bool EnableMenuItem(IntPtr hMenu, uint uIdEnableItem, uint uEnable);

        private const int GwlStyle = -16;

        private const int WsMaximizebox = 0x10000; //maximize button
        private const int WsMinimizebox = 0x20000; //minimize button
        private const uint MfGrayed = 0x00000001;
        private const uint MfEnabled = 0x00000000;
        private const uint ScClose = 0xF060;

        /// <summary>
        /// Disable minimize button
        /// </summary>
        /// <param name="window">Window to disable the minimize button for</param>
        /// <exception cref="InvalidOperationException">The window has not yet been completely initialized</exception>
        public static void DisableMinimizeButton(Window window)
        {
            var windowHandle = new WindowInteropHelper(window).Handle;

            if (windowHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("The window has not yet been completely initialized");
            }

            SetWindowLong(windowHandle, GwlStyle, GetWindowLong(windowHandle, GwlStyle) & ~WsMinimizebox);
        }

        /// <summary>
        /// Disable maximize button
        /// </summary>
        /// <param name="window">Window to disable the minimize button for</param>
        /// <exception cref="InvalidOperationException">The window has not yet been completely initialized</exception>
        public static void DisableMaximizeButton(Window window)
        {
            var windowHandle = new WindowInteropHelper(window).Handle;

            if (windowHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("The window has not yet been completely initialized");
            }

            SetWindowLong(windowHandle, GwlStyle, GetWindowLong(windowHandle, GwlStyle) & ~WsMaximizebox);
        }

        /// <summary>
        /// Disable close button
        /// </summary>
        /// <param name="window">Window to disable the close button for</param>
        /// <exception cref="InvalidOperationException">The window has not yet been completely initialized</exception>
        public static void DisableCloseButton(Window window)
        {
            var windowHandle = new WindowInteropHelper(window).Handle;

            if (windowHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("The window has not yet been completely initialized");
            }


            var hMenu = GetSystemMenu(windowHandle, false);
            EnableMenuItem(hMenu, ScClose, MfGrayed);
        }

        /// <summary>
        /// Enable close button
        /// </summary>
        /// <param name="window">Window to enable the close button for</param>
        /// <exception cref="InvalidOperationException">The window has not yet been completely initialized</exception>
        public static void EnableCloseButton(Window window)
        {
            var windowHandle = new WindowInteropHelper(window).Handle;

            if (windowHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("The window has not yet been completely initialized");
            }

            var hMenu = GetSystemMenu(windowHandle, false);
            EnableMenuItem(hMenu, ScClose, MfEnabled);
        }

        /// <summary>
        /// List of available image formats for export of visuals
        /// </summary>
        public enum ImageFormat
        {
#pragma warning disable 1591
            Jpeg,
            Png,
            Bmp,
            Gif,
            Tif
#pragma warning restore 1591
        }


        ///// <summary>
        ///// Find a resource in a ressource dictionary
        ///// </summary>
        ///// <typeparam name="T">Type the resource has to be converted to</typeparam>
        ///// <param name="ressourceName">name of the requested ressource</param>
        ///// <param name="path">path to load the ressource dictionary from</param>
        ///// <returns></returns>
        //public static T FindResource<T>(string ressourceName, string path)
        //{
        //    try
        //    {


        //        return Resour;
        //    }
        //    catch
        //    {
        //        return default(T);
        //    }
        //}




        /// <summary>
        /// Find a resource in the current application
        /// </summary>
        /// <typeparam name="T">Type the resource has to be converted to</typeparam>
        /// <param name="ressourceName">Name of the requested ressource</param>
        /// <returns></returns>
        public static T FindResourceCurrent<T>(string ressourceName)
        {
            try
            {
                return (T)System.Windows.Application.Current.Resources[ressourceName];
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Dump the visual tree to debug window
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="level"></param>
        public static void DumpVisualTree(DependencyObject parent, int level)
        {
            if (parent == null) return;

            var typeName = parent.GetType().Name;
            var name = (string)(parent.GetValue(FrameworkElement.NameProperty) ?? "");



            Trace.WriteLine($"{string.Empty.PadLeft(level)}{typeName}: {name}");

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                DumpVisualTree(child, level + 1);
            }
        }

        /// <summary>
        /// Dump logical tree to debug window
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="level"></param>
        public static void DumpLogicalTree(object parent, int level)
        {
            var typeName = parent.GetType().Name;
            string name;
            var doParent = parent as DependencyObject;
            // Not everything in the logical tree is a dependency object
            if (doParent != null)
            {
                name = (string)(doParent.GetValue(FrameworkElement.NameProperty) ?? "");
            }
            else
            {
                name = parent.ToString();
            }

            Trace.WriteLine(string.Empty.PadLeft(level) + $"{typeName}: {name}".PadLeft(level));

            if (doParent == null) return;

            foreach (var child in LogicalTreeHelper.GetChildren(doParent))
            {
                DumpLogicalTree(child, level + 1);
            }
        }

        /// <summary>
        /// Renders a visual into a memory stream
        /// </summary>
        /// <param name="visual">the visual to render</param>
        /// <param name="width">requested width for the bitmap</param>
        /// <param name="height">requested height for the bitmap</param>
        /// <param name="format">image format of the bitmap file</param>
        /// <returns>memory stream of the image file</returns>
        public static MemoryStream RenderVisualToImageStream(Visual visual, int width, int height, ImageFormat format)
        {
            var stream = new MemoryStream();

            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {

                BitmapEncoder encoder;

                switch (format)
                {
                    case ImageFormat.Jpeg:
                        encoder = new JpegBitmapEncoder();
                        break;
                    case ImageFormat.Png:
                        encoder = new PngBitmapEncoder();
                        break;
                    case ImageFormat.Bmp:
                        encoder = new BmpBitmapEncoder();
                        break;
                    case ImageFormat.Gif:
                        encoder = new GifBitmapEncoder();
                        break;
                    case ImageFormat.Tif:
                        encoder = new TiffBitmapEncoder();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("format", format, null);
                }

                var rtb = RenderVisualToBitmap(visual, width, height);

                encoder.Frames.Add(BitmapFrame.Create(rtb));
                encoder.Save(stream);
            });

            return stream;
        }

        /// <summary>
        /// Renders a visual into a bitmap
        /// </summary>
        /// <param name="visual">the visual to render</param>
        /// <param name="width">requested width for the bitmap</param>
        /// <param name="height">requested height for the bitmap</param>
        /// <returns></returns>
        public static RenderTargetBitmap RenderVisualToBitmap(Visual visual, int width, int height)
        {
            var rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            rtb.Render(visual);
            return rtb;
        }


        /// <summary>
        /// Renders a canvas into a memory stream
        /// </summary>
        /// <param name="canvas">the canvas to render</param>
        /// <param name="width">requested width for the bitmap</param>
        /// <param name="height">requested height for the bitmap</param>
        /// <param name="format">image format of the bitmap file</param>
        /// <returns>memory stream of the image file</returns>
        public static MemoryStream RenderCanvasToImageStream(Canvas canvas, int width, int height, ImageFormat format)
        {
            var stream = new MemoryStream();

            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                BitmapEncoder encoder;

                switch (format)
                {
                    case ImageFormat.Jpeg:
                        encoder = new JpegBitmapEncoder();
                        break;
                    case ImageFormat.Png:
                        encoder = new PngBitmapEncoder();
                        break;
                    case ImageFormat.Bmp:
                        encoder = new BmpBitmapEncoder();
                        break;
                    case ImageFormat.Gif:
                        encoder = new GifBitmapEncoder();
                        break;
                    case ImageFormat.Tif:
                        encoder = new TiffBitmapEncoder();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("format", format, null);
                }


                // Save current canvas transform
                var transform = canvas.LayoutTransform;
                // reset current transform (in case it is scaled or rotated)
                canvas.LayoutTransform = null;

                // Get the size of canvas
                var size = new Size(canvas.Width, canvas.Height);

                // Measure and arrange the surface
                // VERY IMPORTANT
                canvas.Measure(size);
                canvas.Arrange(new Rect(size));
                canvas.UpdateLayout();

                // Create a render bitmap and push the surface to it
                var renderBitmap = new RenderTargetBitmap(
                    (int)size.Width,
                    (int)size.Height,
                    96d,
                    96d,
                    PixelFormats.Pbgra32);
                for (var i = 0; i < canvas.Children.Count; i++)
                {
                    renderBitmap.Render(canvas.Children[i]);
                }

                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                encoder.Save(stream);

                // Restore previously saved layout
                canvas.LayoutTransform = transform;



            });

            return stream;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="path"></param>
        /// <param name="format"></param>
        public static void RenderCanvasToFile(Canvas canvas, int width, int height, string path, ImageFormat format)
        {

            //Matrix transform = PresentationSource.FromVisual(canvas).CompositionTarget.TransformToDevice;
            //var stream = RenderCanvasToImageStream(canvas, (int)(width * transform.M11), (int)(height * transform.M22), format);

            var stream = RenderCanvasToImageStream(canvas, width, height, format);


            if (File.Exists(path)) File.Delete(path);

            using (var fstream = File.OpenWrite(path))
            {
                stream.WriteTo(fstream);
                fstream.Flush();
                fstream.Close();
            }


        }

        /// <summary>
        /// Render a canvas to a image file
        /// </summary>
        /// <param name="data">Needed data for the export of a Canvas to a file</param>
        public static void RenderCanvasToFile(VisualExportData data)
        {
            RenderCanvasToFile((Canvas)data.Visual, data.Width, data.Height, data.Path, data.ImageFormat);
        }

        /// <summary>
        /// Save an WPF element as XAML file
        /// </summary>
        /// <param name="element">Framework element providing the XAML</param>
        /// <param name="fileName">Path to the XAML to</param>
        public static void SaveElementAsXamlFile(FrameworkElement element, string fileName)
        {
            var xamlString = XamlWriter.Save(element);

            if (File.Exists(fileName)) File.Delete(fileName);

            using (var sr = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                sr.Write(xamlString);
            }
        }


        /// <summary>
        /// Load an WPF element from a XAML file
        /// </summary>
        /// <param name="fileName">File containing the XAML code</param>
        /// <returns></returns>
        public static object LoadElementFromXamlFile(string fileName)
        {
            var s = new FileStream(fileName, FileMode.Open);
            var erg = XamlReader.Load(s);
            s.Close();
            return erg;
        }


        /// <summary>
        /// Load a plain text file with UTF-8 coding into a string
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string LoadPlainTextFile(string path)
        {
            path = path.Replace("pack://siteOfOrigin:,,,", AppDomain.CurrentDomain.BaseDirectory).Replace("/", "\\");

            var erg = File.ReadAllText(path, Encoding.UTF8);

            return erg;
        }


        /// <summary>
        /// Print a visual
        /// </summary>
        /// <param name="visual">Visual object to print</param>
        public static void PrintVisual(Visual visual)
        {
            PrintVisual(visual, "The picture is drawn dynamically");
        }

        /// <summary>
        /// Print a visual
        /// </summary>
        /// <param name="visual">Visual object to print</param>
        /// <param name="message">Message to print on printed Visual</param>
        public static void PrintVisual(Visual visual, string message)
        {
            var dlg = new PrintDialog();
            dlg.PrintVisual(visual, message);
        }

    }
}
