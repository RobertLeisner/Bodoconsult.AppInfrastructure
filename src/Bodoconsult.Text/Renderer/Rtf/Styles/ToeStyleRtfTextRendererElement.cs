using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ToeStyle"/> instances
/// </summary>
public class ToeStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeStyleRtfTextRendererElement(ToeStyle style) : base(style)
    {
        _style = style;
        ClassName = "ToeStyle";
    }
}