// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TofHeadingStyle"/> instances
/// </summary>
public class TofHeadingStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly TofHeadingStyle _tofHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofHeadingStyleWpfTextRendererElement(TofHeadingStyle tofHeadingStyle) : base(tofHeadingStyle)
    {
        _tofHeadingStyle = tofHeadingStyle;
        ClassName = "TofHeadingStyle";
    }
}