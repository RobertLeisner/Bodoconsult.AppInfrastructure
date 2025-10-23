// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.


// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="FooterStyle"/> instances
/// </summary>
public class FooterStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly FooterStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FooterStyleWpfTextRendererElement(FooterStyle style) : base(style)
    {
        _style = style;
        ClassName = "FooterStyle";
    }
}