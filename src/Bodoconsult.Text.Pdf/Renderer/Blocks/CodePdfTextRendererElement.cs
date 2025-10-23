// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Code"/> instances
/// </summary>
public class CodePdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Code _code;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CodePdfTextRendererElement(Code code) : base(code)
    {
        _code = code;
        ClassName = code.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddCode(Content.ToString());
    }
}