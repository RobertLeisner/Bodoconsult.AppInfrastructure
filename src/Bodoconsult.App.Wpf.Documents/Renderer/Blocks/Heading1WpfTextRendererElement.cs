// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Heading1"/> instances
/// </summary>
public class Heading1WpfTextRendererElement : HeadingBaseWpfTextRendererElement
{
    private readonly Heading1 _heading1;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading1WpfTextRendererElement(Heading1 heading1) : base(heading1)
    {
        _heading1 = heading1;
        ClassName = heading1.StyleName;
    }
}