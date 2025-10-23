using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TableHeaderCenterStyle"/> instances
/// </summary>
public class TableHeaderCenterStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderCenterStyleRtfTextRendererElement(TableHeaderCenterStyle style) : base(style)
    {
        _style = style;
        ClassName = "TableHeaderCenterStyle";
    }
}