using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="CellCenterStyle"/> instances
/// </summary>
public class CellCenterStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellCenterStyleRtfTextRendererElement(CellCenterStyle style) : base(style)
    {
        _style = style;
        ClassName = "CellCenterStyle";
    }
}