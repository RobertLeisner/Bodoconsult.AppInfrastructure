// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Warning"/> instances
/// </summary>
public class WarningPdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Warning _warning;

    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningPdfTextRendererElement(Warning warning) : base(warning)
    {
        _warning = warning;
        ClassName = warning.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddWarning(Content.ToString());
    }
}