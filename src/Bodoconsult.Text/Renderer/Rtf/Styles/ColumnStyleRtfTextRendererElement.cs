using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ColumnStyle"/> instances
/// </summary>
public class ColumnStyleRtfTextRendererElement : ITextRendererElement
{
    private readonly ColumnStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ColumnStyleRtfTextRendererElement(ColumnStyle style)
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