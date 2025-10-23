// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Subtitle"/> instances
/// </summary>
public class SubtitlePdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Subtitle _subtitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitlePdfTextRendererElement(Subtitle subtitle) : base(subtitle)
    {
        _subtitle = subtitle;
        ClassName = subtitle.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddSubtitle(Content.ToString());
    }
}