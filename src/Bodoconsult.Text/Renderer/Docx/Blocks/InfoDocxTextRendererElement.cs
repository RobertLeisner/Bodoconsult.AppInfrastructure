// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Info"/> instances
/// </summary>
public class InfoDocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly Info _info;

    /// <summary>
    /// Default ctor
    /// </summary>
    public InfoDocxTextRendererElement(Info info) : base(info)
    {
        _info = info;
        ClassName = info.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        //base.RenderIt(renderer);
        //Documents.Paragraph = renderer.DocxDocument.AddInfo(Content.ToString());
    }
}