// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="CitationSourceStyle"/> instances
/// </summary>
public class CitationSourceStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly CitationSourceStyle _citationSourceStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationSourceStyleWpfTextRendererElement(CitationSourceStyle citationSourceStyle) : base(citationSourceStyle)
    {
        _citationSourceStyle = citationSourceStyle;
        ClassName = "CitationSourceStyle";
    }
}