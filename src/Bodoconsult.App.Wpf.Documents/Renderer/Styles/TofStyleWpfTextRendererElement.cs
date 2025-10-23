// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TofStyle"/> instances
/// </summary>
public class TofStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly TofStyle _tofStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofStyleWpfTextRendererElement(TofStyle tofStyle) : base(tofStyle)
    {
        _tofStyle = tofStyle;
        ClassName = "TofStyle";
    }
}