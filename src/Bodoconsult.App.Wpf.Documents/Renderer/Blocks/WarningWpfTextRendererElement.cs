// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Warning"/> instances
/// </summary>
public class WarningWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Warning _warning;

    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningWpfTextRendererElement(Warning warning) : base(warning)
    {
        _warning = warning;
        ClassName = warning.StyleName;
    }
}