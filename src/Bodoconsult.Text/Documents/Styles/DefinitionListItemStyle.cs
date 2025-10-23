namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="DefinitionListTerm"/> instances
/// </summary>
public class DefinitionListItemStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItemStyle()
    {
        TagToUse = "DefinitionListItemStyle";
        Name = TagToUse;
        Margins.Left = 0;
        FontSize = Styleset.DefaultFontSize;
        Italic = false;
        Bold = false;
    }
}