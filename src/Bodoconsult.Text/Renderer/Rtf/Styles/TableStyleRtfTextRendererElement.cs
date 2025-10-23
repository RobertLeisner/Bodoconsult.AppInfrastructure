using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TableStyle"/> instances
/// </summary>
public class TableStyleRtfTextRendererElement : ITextRendererElement
{
    private readonly TableStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableStyleRtfTextRendererElement(TableStyle style)
    {
        _style = style;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {

    }
}