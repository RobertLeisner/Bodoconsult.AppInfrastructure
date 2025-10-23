namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="DefinitionListTerm"/> instances
/// </summary>
public class DefinitionListTermStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListTermStyle()
    {
        TagToUse = "DefinitionListTermStyle";
        Name = TagToUse;
        Margins.Left = 0;
        FontSize = Styleset.DefaultFontSize;
        Italic = true;
        Bold = false;
    }
}