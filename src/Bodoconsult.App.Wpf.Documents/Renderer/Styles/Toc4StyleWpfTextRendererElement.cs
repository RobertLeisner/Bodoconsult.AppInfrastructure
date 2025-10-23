// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="Toc4Style"/> instances
/// </summary>
public class Toc4StyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly Toc4Style _toc4Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc4StyleWpfTextRendererElement(Toc4Style toc4Style) : base(toc4Style)
    {
        _toc4Style = toc4Style;
        ClassName = "Toc4Style";
    }
}