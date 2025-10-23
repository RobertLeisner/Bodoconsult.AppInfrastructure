// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Error"/> instances
/// </summary>
public class ErrorPdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Error _error;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ErrorPdfTextRendererElement(Error error) : base(error)
    {
        _error = error;
        ClassName = error.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddError(Content.ToString());
    }
}