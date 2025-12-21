using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TitleStyle"/> instances
/// </summary>
public class TitleStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly TitleStyle _titleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TitleStyleDocxTextRendererElement(TitleStyle titleStyle) : base(titleStyle)
    {
        _titleStyle = titleStyle;
        ClassName = "TitleStyle";
    }
}