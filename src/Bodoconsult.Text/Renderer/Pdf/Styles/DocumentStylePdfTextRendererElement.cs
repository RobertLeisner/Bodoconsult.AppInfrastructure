using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Pdf.Styles;

/// <summary>
/// PDF rendering element for <see cref="DocumentStyle"/> instances
/// </summary>
public class DocumentStylePdfTextRendererElement : PdfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _documentStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DocumentStylePdfTextRendererElement(DocumentStyle documentStyle) : base(documentStyle)
    {
        _documentStyle = documentStyle;
        ClassName = "DocumentStyle";
    }
}