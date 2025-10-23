// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Heading4"/> instances
/// </summary>
public class Heading4PdfTextRendererElement : HeadingBasePdfTextRendererElement
{
    private readonly Heading4 _heading4;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading4PdfTextRendererElement(Heading4 heading4) : base(heading4)
    {
        _heading4 = heading4;
        ClassName = heading4.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddHeading4(Content.ToString(), _heading4.TagName);
    }
}