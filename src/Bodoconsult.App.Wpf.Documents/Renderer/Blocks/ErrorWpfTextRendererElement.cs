// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Error"/> instances
/// </summary>
public class ErrorWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Error _error;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ErrorWpfTextRendererElement(Error error) : base(error)
    {
        _error = error;
        ClassName = error.StyleName;
    }
}