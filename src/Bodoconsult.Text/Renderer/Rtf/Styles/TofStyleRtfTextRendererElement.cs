using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TofStyle"/> instances
/// </summary>
public class TofStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofStyleRtfTextRendererElement(TofStyle style) : base(style)
    {
        _style = style;
        ClassName = "TofStyle";
    }
}