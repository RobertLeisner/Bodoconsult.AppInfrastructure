// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="SectionTitle"/> instances
/// </summary>
public class SectionTitleDocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly SectionTitle _sectionTitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleDocxTextRendererElement(SectionTitle sectionTitle) : base(sectionTitle)
    {
        _sectionTitle = sectionTitle;
        ClassName = sectionTitle.StyleName;
    }
}