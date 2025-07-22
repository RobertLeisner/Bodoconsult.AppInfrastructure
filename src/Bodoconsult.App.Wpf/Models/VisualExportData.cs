using System.Windows.Media;
using Bodoconsult.App.Wpf.Utilities;

namespace Bodoconsult.App.Wpf.Models
{
    /// <summary>
    /// Data needed for exporting a chart as image file
    /// </summary>
//    [AddINotifyPropertyChangedInterface]
    public class VisualExportData
    {

        /// <summary>
        ///  default ctor
        /// </summary>
        public VisualExportData()
        {
            ImageFormat = WpfUtility.ImageFormat.Png;
            Width = 1024;
            Height = 768;
        }

        /// <summary>
        /// Visual to export as file
        /// </summary>
        public Visual Visual { get; set; }

        /// <summary>
        /// Image format for the chart export
        /// </summary>
        public WpfUtility.ImageFormat ImageFormat { get; set; }

        /// <summary>
        /// path to save the exported chart
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Width in pixels of the exported chart. Default: 1024px
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height in pixels of the exported chart. Default: 768px
        /// </summary>
        public int Height { get; set; }
    }
}
