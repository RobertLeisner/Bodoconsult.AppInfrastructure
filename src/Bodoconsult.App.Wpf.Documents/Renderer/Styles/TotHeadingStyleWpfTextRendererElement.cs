// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TotHeadingStyle"/> instances
/// </summary>
public class TotHeadingStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly TotHeadingStyle _totHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotHeadingStyleWpfTextRendererElement(TotHeadingStyle totHeadingStyle) : base(totHeadingStyle)
    {
        _totHeadingStyle = totHeadingStyle;
        ClassName = "TotHeadingStyle";
    }
}