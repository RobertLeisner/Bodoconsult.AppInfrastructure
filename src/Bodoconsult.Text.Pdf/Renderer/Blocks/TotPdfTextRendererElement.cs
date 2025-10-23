// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Tot"/> instances
/// </summary>
public class TotPdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Tot _tot;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotPdfTextRendererElement(Tot tot) : base(tot)
    {
        _tot = tot;
        ClassName = tot.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddTotEntry(Content.ToString(), Block.TagName);
    }
}