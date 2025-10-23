// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="Toc2Style"/> instances
/// </summary>
public class Toc2StyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly Toc2Style _toc2Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc2StyleWpfTextRendererElement(Toc2Style toc2Style) : base(toc2Style)
    {
        _toc2Style = toc2Style;
        ClassName = "Toc2Style";
    }
}