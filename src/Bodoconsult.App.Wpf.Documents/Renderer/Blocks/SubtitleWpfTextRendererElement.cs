// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Subtitle"/> instances
/// </summary>
public class SubtitleWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Subtitle _subtitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitleWpfTextRendererElement(Subtitle subtitle) : base(subtitle)
    {
        _subtitle = subtitle;
        ClassName = subtitle.StyleName;
    }
}