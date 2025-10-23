namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="DefinitionList"/> instances
/// </summary>
public class DefinitionListStyle : StyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListStyle()
    {
        TagToUse = "DefinitionListStyle";
        Name = TagToUse;
    }

    /// <summary>
    /// Margins. Margin left and right are ignored. Definitionlist is always on full page width
    /// </summary>
    public Thickness Margins { get; set; } = new(0, Styleset.DefaultFontSize, 0, 0);
}