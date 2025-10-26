// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Heading2"/> instances
/// </summary>
public class Heading2WpfTextRendererElement : HeadingBaseWpfTextRendererElement
{
    private readonly Heading2 _heading2;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2WpfTextRendererElement(Heading2 heading2) : base(heading2)
    {
        _heading2 = heading2;
        ClassName = heading2.StyleName;
    }
}