// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Toc4"/> instances
/// </summary>
public class Toc4WpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Toc4 _toc4;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc4WpfTextRendererElement(Toc4 toc4) : base(toc4)
    {
        _toc4 = toc4;
        ClassName = toc4.StyleName;
    }
}