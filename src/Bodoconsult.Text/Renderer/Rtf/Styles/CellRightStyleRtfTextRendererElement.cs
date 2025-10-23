using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="CellRightStyle"/> instances
/// </summary>
public class CellRightStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellRightStyleRtfTextRendererElement(CellRightStyle style) : base(style)
    {
        _style = style;
        ClassName = "CellRightStyle";
    }
}