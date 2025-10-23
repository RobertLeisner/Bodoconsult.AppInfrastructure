// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="Toc3Style"/> instances
/// </summary>
public class Toc3StyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly Toc3Style _toc3Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc3StyleWpfTextRendererElement(Toc3Style toc3Style) : base(toc3Style)
    {
        _toc3Style = toc3Style;
        ClassName = "Toc3Style";
    }
}