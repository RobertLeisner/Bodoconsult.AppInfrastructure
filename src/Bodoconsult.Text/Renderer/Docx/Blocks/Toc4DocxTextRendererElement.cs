// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Toc4"/> instances
/// </summary>
public class Toc4DocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly Toc4 _toc4;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc4DocxTextRendererElement(Toc4 toc4) : base(toc4)
    {
        _toc4 = toc4;
        ClassName = toc4.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        //base.RenderIt(renderer);
        //Documents.Paragraph = renderer.DocxDocument.AddToc4Entry(Content.ToString(), Documents.Block.TagName);
    }
}