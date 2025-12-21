// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Heading4"/> instances
/// </summary>
public class Heading4DocxTextRendererElement : HeadingBaseDocxTextRendererElement
{
    private readonly Heading4 _heading4;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading4DocxTextRendererElement(Heading4 heading4) : base(heading4)
    {
        _heading4 = heading4;
        ClassName = heading4.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        //base.RenderIt(renderer);
        //Documents.Paragraph = renderer.DocxDocument.AddHeading4(Content.ToString(), _heading4.TagName);
    }
}