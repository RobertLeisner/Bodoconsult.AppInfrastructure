// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TocHeadingStyle"/> instances
/// </summary>
public class ToeHeadingStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly ToeHeadingStyle _toeHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeHeadingStyleWpfTextRendererElement(ToeHeadingStyle toeHeadingStyle) : base(toeHeadingStyle)
    {
        _toeHeadingStyle = toeHeadingStyle;
        ClassName = "ToeHeadingStyle";
    }
}