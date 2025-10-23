// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="ToeStyle"/> instances
/// </summary>
public class ToeStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly ToeStyle _toeStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeStyleWpfTextRendererElement(ToeStyle toeStyle) : base(toeStyle)
    {
        _toeStyle = toeStyle;
        ClassName = "TotStyle";
    }
}