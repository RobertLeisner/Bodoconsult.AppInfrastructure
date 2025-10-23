namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for footer instances
/// </summary>
public class FooterStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public FooterStyle()
    {
        TagToUse = "FooterStyle";
        Name = TagToUse;
        FontName = Styleset.DefaultFontName;
        FontSize = Styleset.DefaultFontSize - 4;
    }
}