// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Heading3"/> instances
/// </summary>
public class Heading3WpfTextRendererElement : HeadingBaseWpfTextRendererElement
{
    private readonly Heading3 _heading3;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3WpfTextRendererElement(Heading3 heading3) : base(heading3)
    {
        _heading3 = heading3;
        ClassName = heading3.StyleName;
    }
}