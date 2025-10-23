// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TocHeadingStyle"/> instances
/// </summary>
public class TocHeadingStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly TocHeadingStyle _tocHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocHeadingStyleWpfTextRendererElement(TocHeadingStyle tocHeadingStyle) : base(tocHeadingStyle)
    {
        _tocHeadingStyle = tocHeadingStyle;
        ClassName = "TocHeadingStyle";
    }
}