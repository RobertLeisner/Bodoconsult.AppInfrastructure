using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TotHeadingStyle"/> instances
/// </summary>
public class TotHeadingStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotHeadingStyleRtfTextRendererElement(TotHeadingStyle style) : base(style)
    {
        _style = style;
        ClassName = "TotHeadingStyle";
    }
}