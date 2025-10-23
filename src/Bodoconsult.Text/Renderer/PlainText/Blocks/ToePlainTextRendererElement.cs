using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Toe"/> instances
/// </summary>
public class ToePlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ToePlainTextRendererElement(Toe toe)
    {
        Paragraph = toe;
    }
}