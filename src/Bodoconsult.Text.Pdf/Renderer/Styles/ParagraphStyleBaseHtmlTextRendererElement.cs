using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="ParagraphStyleBase"/> instances
/// </summary>
public class ParagraphStyleBasePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _paragraphStyleBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphStyleBasePdfTextRendererElement(ParagraphStyleBase paragraphStyleBase) : base(paragraphStyleBase)
    {
        _paragraphStyleBase = paragraphStyleBase;
        ClassName = "ParagraphStyleBase";
    }
}