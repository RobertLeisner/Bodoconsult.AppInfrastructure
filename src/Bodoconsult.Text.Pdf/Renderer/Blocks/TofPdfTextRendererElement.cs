// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Tof"/> instances
/// </summary>
public class TofPdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Tof _tof;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofPdfTextRendererElement(Tof tof) : base(tof)
    {
        _tof = tof;
        ClassName = tof.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddTofEntry(Content.ToString(), Block.TagName);
    }
}