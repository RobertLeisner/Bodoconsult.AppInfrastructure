// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;
using Paragraph = System.Windows.Documents.Paragraph;

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