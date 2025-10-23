using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="CellLeftStyle"/> instances
/// </summary>
public class CellLeftStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellLeftStyleRtfTextRendererElement(CellLeftStyle style) : base(style)
    {
        _style = style;
        ClassName = "CellLeftStyle";
    }
}