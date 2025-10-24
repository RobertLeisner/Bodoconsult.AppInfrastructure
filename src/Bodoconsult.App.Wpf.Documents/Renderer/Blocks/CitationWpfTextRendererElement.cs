// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Citation"/> instances
/// </summary>
public class CitationWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Citation _citation;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationWpfTextRendererElement(Citation citation) : base(citation)
    {
        _citation = citation;
        ClassName = citation.StyleName;
    }
}

