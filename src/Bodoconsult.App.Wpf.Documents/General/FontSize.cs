namespace Bodoconsult.App.Wpf.Documents.General;

/// <summary>
/// Font size to use in the WPF report
/// </summary>
public enum FontSize
{
    /// <summary>
    /// Regular font size. Good readability
    /// </summary>
    Regular,
    /// <summary>
    /// Smaller font size for more compact layout. Readability okay
    /// </summary>
    Small,

    /// <summary>
    /// Extra small font size for very compact layout. Readability less good. Intended for documentation not read every day.
    /// </summary>
    ExtraSmall
}