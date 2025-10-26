// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Toe"/> instances
/// </summary>
public class ToeWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Toe _toe;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeWpfTextRendererElement(Toe toe) : base(toe)
    {
        _toe = toe;
        ClassName = toe.StyleName;
    }
}