// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Section"/> instances
/// </summary>
public class SectionDocxTextRendererElement : SectionBaseDocxTextRendererElement
{
    private readonly Section _section;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionDocxTextRendererElement(Section section) : base(section)
    {
        _section = section;
        ClassName = section.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        RenderItInternal(renderer, _section, "XXX", string.Empty);
    }
}