// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Heading2"/> instances
/// </summary>
public class Heading2PdfTextRendererElement : HeadingBasePdfTextRendererElement
{
    private readonly Heading2 _heading2;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2PdfTextRendererElement(Heading2 heading2) : base(heading2)
    {
        _heading2 = heading2;
        ClassName = heading2.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddHeading2(Content.ToString(), _heading2.TagName);
    }
}