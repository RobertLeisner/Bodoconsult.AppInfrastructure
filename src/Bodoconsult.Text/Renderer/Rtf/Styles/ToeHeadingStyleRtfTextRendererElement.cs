using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ToeHeadingStyle"/> instances
/// </summary>
public class ToeHeadingStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeHeadingStyleRtfTextRendererElement(ToeHeadingStyle style) : base(style)
    {
        _style = style;
        ClassName = "ToeHeadingStyle";
    }
}