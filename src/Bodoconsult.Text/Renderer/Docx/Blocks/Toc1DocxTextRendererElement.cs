// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Toc1"/> instances
/// </summary>
public class Toc1DocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly Toc1 _toc1;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1DocxTextRendererElement(Toc1 toc1) : base(toc1)
    {
        _toc1 = toc1;
        ClassName = toc1.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        //base.RenderIt(renderer);
        //Documents.Paragraph = renderer.DocxDocument.AddToc1Entry(Content.ToString(), Documents.Block.TagName);
    }
}

