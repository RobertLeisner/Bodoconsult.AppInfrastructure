using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TofHeadingStyle"/> instances
/// </summary>
public class TofHeadingStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofHeadingStyleRtfTextRendererElement(TofHeadingStyle style) : base(style)
    {
        _style = style;
        ClassName = "TofHeadingStyle";
    }
}