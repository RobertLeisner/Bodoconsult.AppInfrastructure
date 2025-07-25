//using System.IO;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Markup;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;

//namespace Bodoconsult.App.Wpf.Documents.Utilities
//{
//    /// <summary>
//    /// General utilities for WPF
//    /// </summary>
//    public class WpfUtility
//    {

//        /// <summary>
//        /// List of available image formats for export of visuals
//        /// </summary>
//        public enum ImageFormat
//        {
//#pragma warning disable 1591
//            Jpeg,
//            Png,
//            Bmp,
//            Gif,
//            Tif
//#pragma warning restore 1591
//        }

//        ///// <summary>
//        ///// Find a ressource in the normal template
//        ///// </summary>
//        ///// <param name="ressourceName">name of the requested ressource</param>
//        ///// <returns></returns>
//        //public static object FindResourceNormal(string ressourceName)
//        //{

//        //    var uri = new Uri("/Bodoconsult.Wpf.Documents;component/Resources/Typography.xaml",
//        //        UriKind.RelativeOrAbsolute);

//        //    var myResourceDictionary = new ResourceDictionary
//        //    {
//        //        Source = uri
//        //    };

//        //    return myResourceDictionary[ressourceName];
//        //}


//        ///// <summary>
//        ///// Find a ressource in the compact template
//        ///// </summary>
//        ///// <param name="ressourceName">name of the requested ressource</param>
//        ///// <returns></returns>
//        //public static object FindResourceCompact(string ressourceName)
//        //{

//        //    var uri = new Uri("/Bodoconsult.Wpf.Documents;component/Resources/TypographyCompact.xaml",
//        //        UriKind.RelativeOrAbsolute);

//        //    var myResourceDictionary = new ResourceDictionary
//        //    {
//        //        Source = uri
//        //    };

//        //    return myResourceDictionary[ressourceName];
//        //}


//        ///// <summary>
//        ///// Find a resource in a ressource dictionary
//        ///// </summary>
//        ///// <param name="ressourceName">name of the requested ressource</param>
//        ///// <param name="path">path to load the ressource dictionary from</param>
//        ///// <returns></returns>
//        //public static object FindResource(string ressourceName, string path)
//        //{
//        //    try
//        //    {
//        //        var myResourceDictionary = new ResourceDictionary
//        //        {
//        //            Source = new Uri(path, UriKind.RelativeOrAbsolute)
//        //        };

//        //        return myResourceDictionary[ressourceName];
//        //    }
//        //    catch
//        //    {
//        //        return null;
//        //    }
//        //}

//        ///// <summary>
//        ///// Find a ressource in the compact template
//        ///// </summary>
//        ///// <param name="ressourceName">name of the requested ressource</param>
//        ///// <param name="ressourceFilePath">Absolute or relative path to the resource XAML file</param>
//        ///// <returns></returns>
//        //public static object FindResourceUserDefined(string ressourceName, string ressourceFilePath)
//        //{

//        //    var uri = new Uri(ressourceFilePath,UriKind.RelativeOrAbsolute);

//        //    var myResourceDictionary = new ResourceDictionary
//        //    {
//        //        Source = uri
//        //    };

//        //    return myResourceDictionary[ressourceName];
//        //}

//        /// <summary>
//        /// Renders a visual into a memory stream
//        /// </summary>
//        /// <param name="visual">the visual to render</param>
//        /// <param name="width">requested width for the bitmap</param>
//        /// <param name="height">requested height for the bitmap</param>
//        /// <param name="format">image format of the bitmap file</param>
//        /// <returns>memory stream of the image file</returns>
//        public static MemoryStream RenderVisualToImageStream(Visual visual, int width, int height, ImageFormat format)
//        {
//            BitmapEncoder encoder;

//            switch (format)
//            {
//                case ImageFormat.Jpeg:
//                    encoder = new JpegBitmapEncoder();
//                    break;
//                case ImageFormat.Png:
//                    encoder = new PngBitmapEncoder();
//                    break;
//                case ImageFormat.Bmp:
//                    encoder = new BmpBitmapEncoder();
//                    break;
//                case ImageFormat.Gif:
//                    encoder = new GifBitmapEncoder();
//                    break;
//                case ImageFormat.Tif:
//                    encoder = new TiffBitmapEncoder();
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException("format", format, null);
//            }

//            var rtb = RenderVisualToBitmap(visual, width, height);
//            var stream = new MemoryStream();
//            encoder.Frames.Add(BitmapFrame.Create(rtb));
//            encoder.Save(stream);

//            return stream;
//        }

//        /// <summary>
//        /// Renders a visual into a bitmap
//        /// </summary>
//        /// <param name="visual">the visual to render</param>
//        /// <param name="width">requested width for the bitmap</param>
//        /// <param name="height">requested height for the bitmap</param>
//        /// <returns></returns>
//        public static RenderTargetBitmap RenderVisualToBitmap(Visual visual, int width, int height)
//        {
//            var rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
//            rtb.Render(visual);
//            return rtb;
//        }


//        /// <summary>
//        /// Renders a canvas into a memory stream
//        /// </summary>
//        /// <param name="canvas">the canvas to render</param>
//        /// <param name="width">requested width for the bitmap</param>
//        /// <param name="height">requested height for the bitmap</param>
//        /// <param name="format">image format of the bitmap file</param>
//        /// <returns>memory stream of the image file</returns>
//        public static MemoryStream RenderCanvasToImageStream(Canvas canvas, int width, int height, ImageFormat format)
//        {
//            BitmapEncoder encoder;

//            switch (format)
//            {
//                case ImageFormat.Jpeg:
//                    encoder = new JpegBitmapEncoder();
//                    break;
//                case ImageFormat.Png:
//                    encoder = new PngBitmapEncoder();
//                    break;
//                case ImageFormat.Bmp:
//                    encoder = new BmpBitmapEncoder();
//                    break;
//                case ImageFormat.Gif:
//                    encoder = new GifBitmapEncoder();
//                    break;
//                case ImageFormat.Tif:
//                    encoder = new TiffBitmapEncoder();
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException("format", format, null);
//            }


//            // Save current canvas transform
//            var transform = canvas.LayoutTransform;
//            // reset current transform (in case it is scaled or rotated)
//            canvas.LayoutTransform = null;

//            // Get the size of canvas
//            var size = new Size(canvas.Width, canvas.Height);
//            // Measure and arrange the surface
//            // VERY IMPORTANT
//            canvas.Measure(size);
//            canvas.Arrange(new Rect(size));
//            canvas.UpdateLayout();

//            // Create a render bitmap and push the surface to it
//            var renderBitmap = new RenderTargetBitmap(
//                (int)size.Width,
//                (int)size.Height,
//                96d,
//                96d,
//                PixelFormats.Pbgra32);
//            for (var i = 0; i < canvas.Children.Count; i++)
//            {
//                renderBitmap.Render(canvas.Children[i]);
//            }

//            var stream = new MemoryStream();
//            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
//            encoder.Save(stream);

//            // Restore previously saved layout
//            canvas.LayoutTransform = transform;

//            return stream;
//        }

//        /// <summary>
//        /// Load an WPF element from a XAML file
//        /// </summary>
//        /// <param name="fileName">File containing the XAML code</param>
//        /// <returns></returns>
//        public static object LoadElementFromXamlFile(string fileName)
//        {
//            var s = new FileStream(fileName, FileMode.Open);
//            var erg = XamlReader.Load(s);
//            s.Close();
//            return erg;
//        }


//        /// <summary>
//        /// Load a plain text file with UTF-8 coding into a string
//        /// </summary>
//        /// <param name="path"></param>
//        /// <returns></returns>
//        public static string LoadPlainTextFile(string path)
//        {


//            path = path.Replace("pack://siteOfOrigin:,,,", AppDomain.CurrentDomain.BaseDirectory).Replace("/", "\\");
            
//           var erg =  File.ReadAllText(path, Encoding.UTF8);

//            return erg;
//        }

//    }
//}
