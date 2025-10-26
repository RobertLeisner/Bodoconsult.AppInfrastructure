// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Title"/> instances
/// </summary>
public class TitleWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Title _title;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TitleWpfTextRendererElement(Title title) : base(title)
    {
        _title = title;
        ClassName = title.StyleName;
    }
}