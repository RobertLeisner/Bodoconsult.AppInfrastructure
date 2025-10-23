// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Heading3"/> instances
/// </summary>
public class Heading3PdfTextRendererElement : HeadingBasePdfTextRendererElement
{
    private readonly Heading3 _heading3;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3PdfTextRendererElement(Heading3 heading3) : base(heading3)
    {
        _heading3 = heading3;
        ClassName = heading3.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddHeading3(Content.ToString(), _heading3.TagName);
    }
}