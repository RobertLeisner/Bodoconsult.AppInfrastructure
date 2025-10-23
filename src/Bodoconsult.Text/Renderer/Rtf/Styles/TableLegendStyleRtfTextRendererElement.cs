using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TableLegendStyle"/> instances
/// </summary>
public class TableLegendStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableLegendStyleRtfTextRendererElement(TableLegendStyle style) : base(style)
    {
        _style = style;
        ClassName = "TableLegendStyle";
    }
}