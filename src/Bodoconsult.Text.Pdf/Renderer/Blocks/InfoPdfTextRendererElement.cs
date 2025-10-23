// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Info"/> instances
/// </summary>
public class InfoPdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Info _info;

    /// <summary>
    /// Default ctor
    /// </summary>
    public InfoPdfTextRendererElement(Info info) : base(info)
    {
        _info = info;
        ClassName = info.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddInfo(Content.ToString());
    }
}