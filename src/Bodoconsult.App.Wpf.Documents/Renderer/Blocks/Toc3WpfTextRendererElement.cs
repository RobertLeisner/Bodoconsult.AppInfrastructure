// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Toc3"/> instances
/// </summary>
public class Toc3WpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Toc3 _toc3;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc3WpfTextRendererElement(Toc3 toc3) : base(toc3)
    {
        _toc3 = toc3;
        ClassName = toc3.StyleName;
    }
}