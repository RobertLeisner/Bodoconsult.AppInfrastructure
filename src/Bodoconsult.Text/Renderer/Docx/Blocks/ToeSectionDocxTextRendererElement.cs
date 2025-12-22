// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="ToeSection"/> instances
/// </summary>
public class ToeSectionDocxTextRendererElement : SectionBaseDocxTextRendererElement
{
    private readonly ToeSection _toeSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSectionDocxTextRendererElement(ToeSection toeSection) : base(toeSection)
    {
        _toeSection = toeSection;
        ClassName = toeSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        RenderItInternal(renderer, _toeSection, "ToeHeading", renderer.Document.DocumentMetaData.ToeHeading);
    }


}