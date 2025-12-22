// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="TofSection"/> instances
/// </summary>
public class TofSectionDocxTextRendererElement : SectionBaseDocxTextRendererElement
{
    private readonly TofSection _tofSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionDocxTextRendererElement(TofSection tofSection) : base(tofSection)
    {
        _tofSection = tofSection;
        ClassName = tofSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        RenderItInternal(renderer, _tofSection, "TofHeading", renderer.Document.DocumentMetaData.TofHeading);
    }
}