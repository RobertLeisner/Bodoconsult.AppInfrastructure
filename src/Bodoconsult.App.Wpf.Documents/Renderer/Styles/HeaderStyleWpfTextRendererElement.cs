// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.


// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="HeaderStyle"/> instances
/// </summary>
public class HeaderStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly HeaderStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public HeaderStyleWpfTextRendererElement(HeaderStyle style) : base(style)
    {
        _style = style;
        ClassName = "HeaderStyle";
    }
}