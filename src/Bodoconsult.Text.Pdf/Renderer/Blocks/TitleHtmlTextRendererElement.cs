// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Title"/> instances
/// </summary>
public class TitlePdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Title _title;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TitlePdfTextRendererElement(Title title) : base(title)
    {
        _title = title;
        ClassName = title.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddTitle(Content.ToString());
    }
}