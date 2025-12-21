// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="SectionSubtitle"/> instances
/// </summary>
public class SectionSubtitleDocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly SectionSubtitle _sectionSubtitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitleDocxTextRendererElement(SectionSubtitle sectionSubtitle) : base(sectionSubtitle)
    {
        _sectionSubtitle = sectionSubtitle;
        ClassName = sectionSubtitle.StyleName;
    }
}