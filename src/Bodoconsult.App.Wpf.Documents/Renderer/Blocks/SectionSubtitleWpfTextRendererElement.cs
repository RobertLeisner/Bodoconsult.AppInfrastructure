// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="SectionSubtitle"/> instances
/// </summary>
public class SectionSubtitleWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly SectionSubtitle _sectionSubtitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitleWpfTextRendererElement(SectionSubtitle sectionSubtitle) : base(sectionSubtitle)
    {
        _sectionSubtitle = sectionSubtitle;
        ClassName = sectionSubtitle.StyleName;
    }
}