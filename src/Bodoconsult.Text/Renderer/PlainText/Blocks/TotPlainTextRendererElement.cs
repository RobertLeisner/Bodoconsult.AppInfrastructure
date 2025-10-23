using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Tot"/> instances
/// </summary>
public class TotPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TotPlainTextRendererElement(Tot tot)
    {
        Paragraph = tot;
    }
}