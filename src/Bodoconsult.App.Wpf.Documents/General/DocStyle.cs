namespace Bodoconsult.Wpf.Documents.General
{
    /// <summary>
    /// How should the document be formatted
    /// </summary>
    public enum DocStyle
    {
        /// <summary>
        /// Normal, regular styling of the report
        /// </summary>
        Normal,
        /// <summary>
        /// Compact styling uses smaller font sizes and smaller margins
        /// </summary>
        Compact,

        /// <summary>
        /// Use an individual XAML file with resources to format the document
        /// </summary>
        UserDefined



    }
}