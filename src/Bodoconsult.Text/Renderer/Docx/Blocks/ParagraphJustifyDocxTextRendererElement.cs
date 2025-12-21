// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="ParagraphJustify"/> instances
/// </summary>
public class ParagraphJustifyDocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly ParagraphJustify _paragraphJustify;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphJustifyDocxTextRendererElement(ParagraphJustify paragraphJustify) : base(paragraphJustify)
    {
        _paragraphJustify = paragraphJustify;
        ClassName = paragraphJustify.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        //base.RenderIt(renderer);
        //Documents.Paragraph = renderer.DocxDocument.AddParagraphJustify(Content.ToString());
    }
}