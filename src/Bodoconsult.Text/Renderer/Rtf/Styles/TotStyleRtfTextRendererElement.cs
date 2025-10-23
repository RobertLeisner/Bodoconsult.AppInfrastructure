using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TotStyle"/> instances
/// </summary>
public class TotStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotStyleRtfTextRendererElement(TotStyle style) : base(style)
    {
        _style = style;
        ClassName = "TotStyle";
    }
}