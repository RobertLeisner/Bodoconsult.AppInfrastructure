// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="SectionTitle"/> instances
/// </summary>
public class SectionTitleWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly SectionTitle _sectionTitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleWpfTextRendererElement(SectionTitle sectionTitle) : base(sectionTitle)
    {
        _sectionTitle = sectionTitle;
        ClassName = sectionTitle.StyleName;
    }
}