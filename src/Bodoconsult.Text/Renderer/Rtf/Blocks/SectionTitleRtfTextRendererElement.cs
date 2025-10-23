// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="SectionTitle"/> instances
/// </summary>
public class SectionTitleRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly SectionTitle _sectionTitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleRtfTextRendererElement(SectionTitle sectionTitle) : base(sectionTitle)
    {
        _sectionTitle = sectionTitle;
        ClassName = sectionTitle.StyleName;
    }
}