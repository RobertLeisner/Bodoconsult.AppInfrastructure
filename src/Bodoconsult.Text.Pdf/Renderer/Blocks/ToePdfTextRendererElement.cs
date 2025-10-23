// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Toe"/> instances
/// </summary>
public class ToePdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Toe _toe;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToePdfTextRendererElement(Toe toe) : base(toe)
    {
        _toe = toe;
        ClassName = toe.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddToeEntry(Content.ToString(), Block.TagName);
    }
}