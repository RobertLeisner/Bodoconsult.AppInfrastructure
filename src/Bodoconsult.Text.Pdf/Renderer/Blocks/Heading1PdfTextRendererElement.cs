// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Heading1"/> instances
/// </summary>
public class Heading1PdfTextRendererElement : HeadingBasePdfTextRendererElement
{
    private readonly Heading1 _heading1;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading1PdfTextRendererElement(Heading1 heading1) : base(heading1)
    {
        _heading1 = heading1;
        ClassName = heading1.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddHeading1(Content.ToString(), _heading1.TagName);
    }
}