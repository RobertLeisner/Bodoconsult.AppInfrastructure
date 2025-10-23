using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Pdf.Helpers;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="TofSection"/> instances
/// </summary>
public class TofSectionPdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly TofSection _tofSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionPdfTextRendererElement(TofSection tofSection) : base(tofSection)
    {
        _tofSection = tofSection;
        ClassName = tofSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        if (_tofSection.ChildBlocks.Count == 0)
        {
            return;
        }

        if (!string.IsNullOrEmpty(renderer.Document.DocumentMetaData.HeaderText))
        {
            renderer.PdfDocument.SetHeader(renderer.Document.DocumentMetaData.HeaderText);
        }
        if (!string.IsNullOrEmpty(renderer.Document.DocumentMetaData.FooterText))
        {
            renderer.PdfDocument.SetFooter(renderer.Document.DocumentMetaData.FooterText);
        }

        renderer.PdfDocument.CreateTofSection();

        PdfDocumentRendererHelper.RenderBlockChildsToPdf(renderer, Block.ChildBlocks);
    }
}