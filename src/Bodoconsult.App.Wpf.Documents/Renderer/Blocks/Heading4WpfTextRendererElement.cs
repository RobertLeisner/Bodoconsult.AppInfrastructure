// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Heading4"/> instances
/// </summary>
public class Heading4WpfTextRendererElement : HeadingBaseWpfTextRendererElement
{
    private readonly Heading4 _heading4;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading4WpfTextRendererElement(Heading4 heading4) : base(heading4)
    {
        _heading4 = heading4;
        ClassName = heading4.StyleName;
    }
}