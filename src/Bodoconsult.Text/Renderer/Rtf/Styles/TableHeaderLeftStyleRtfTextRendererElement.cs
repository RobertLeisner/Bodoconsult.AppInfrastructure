using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TableHeaderLeftStyle"/> instances
/// </summary>
public class TableHeaderLeftStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderLeftStyleRtfTextRendererElement(TableHeaderLeftStyle style) : base(style)
    {
        _style = style;
        ClassName = "TableHeaderLeftStyle";
    }
}