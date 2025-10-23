// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Heading5"/> instances
/// </summary>
public class Heading5PdfTextRendererElement : HeadingBasePdfTextRendererElement
{
    private readonly Heading5 _heading5;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading5PdfTextRendererElement(Heading5 heading5) : base(heading5)
    {
        _heading5 = heading5;
        ClassName = heading5.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddHeading5(Content.ToString(), _heading5.TagName);
    }
}