// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="SectionSubtitle"/> instances
/// </summary>
public class SectionSubtitleRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly SectionSubtitle _sectionSubtitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitleRtfTextRendererElement(SectionSubtitle sectionSubtitle) : base(sectionSubtitle)
    {
        _sectionSubtitle = sectionSubtitle;
        ClassName = sectionSubtitle.StyleName;
    }
}