// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="Toc5Style"/> instances
/// </summary>
public class Toc5StyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly Toc5Style _toc5Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc5StyleWpfTextRendererElement(Toc5Style toc5Style) : base(toc5Style)
    {
        _toc5Style = toc5Style;
        ClassName = "Toc5Style";
    }
}