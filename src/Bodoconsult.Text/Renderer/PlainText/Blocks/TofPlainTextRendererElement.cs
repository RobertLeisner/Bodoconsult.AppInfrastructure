using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Tof"/> instances
/// </summary>
public class TofPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TofPlainTextRendererElement(Tof tof)
    {
        Paragraph = tof;
    }
}