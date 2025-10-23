using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TocHeadingStyle"/> instances
/// </summary>
public class TocHeadingStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocHeadingStyleRtfTextRendererElement(TocHeadingStyle style) : base(style)
    {
        _style = style;
        ClassName = "TocHeadingStyle";
    }
}