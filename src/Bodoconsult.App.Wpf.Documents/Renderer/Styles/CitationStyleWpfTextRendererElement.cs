// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="CitationStyle"/> instances
/// </summary>
public class CitationStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly CitationStyle _citationStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationStyleWpfTextRendererElement(CitationStyle citationStyle) : base(citationStyle)
    {
        _citationStyle = citationStyle;
        ClassName = "CitationStyle";
    }
}