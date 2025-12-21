// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Paragraph"/> instances
/// </summary>
public class ParagraphDocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly Paragraph _paragraph;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphDocxTextRendererElement(Paragraph paragraph) : base(paragraph)
    {
        _paragraph = paragraph;
        ClassName = paragraph.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        //base.RenderIt(renderer);
        //Documents.Paragraph = renderer.DocxDocument.AddParagraphLeft(Content.ToString());
    }
}