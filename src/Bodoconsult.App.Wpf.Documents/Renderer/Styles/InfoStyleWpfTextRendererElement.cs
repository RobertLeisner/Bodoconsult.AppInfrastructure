// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="InfoStyle"/> instances
/// </summary>
public class InfoStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly InfoStyle _infoStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public InfoStyleWpfTextRendererElement(InfoStyle infoStyle) : base(infoStyle)
    {
        _infoStyle = infoStyle;
        ClassName = "InfoStyle";
    }
}