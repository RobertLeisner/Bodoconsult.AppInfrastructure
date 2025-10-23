namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for header instances
/// </summary>
public class HeaderStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public HeaderStyle()
    {
        TagToUse = "HeaderStyle";
        Name = TagToUse;
        FontName = Styleset.DefaultFontName;
        FontSize = Styleset.DefaultFontSize - 4;
    }
}