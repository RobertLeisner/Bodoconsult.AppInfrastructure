// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TotStyle"/> instances
/// </summary>
public class TotStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly TotStyle _totStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotStyleWpfTextRendererElement(TotStyle totStyle) : base(totStyle)
    {
        _totStyle = totStyle;
        ClassName = "TotStyle";
    }
}