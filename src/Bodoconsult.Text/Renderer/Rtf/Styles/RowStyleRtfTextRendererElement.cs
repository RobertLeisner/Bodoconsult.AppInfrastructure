using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="RowStyle"/> instances
/// </summary>
public class RowStyleRtfTextRendererElement : ITextRendererElement
{
    private readonly RowStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public RowStyleRtfTextRendererElement(RowStyle style)
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