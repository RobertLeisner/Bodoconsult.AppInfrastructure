// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TocSectionStyle"/> instances
/// </summary>
public class TocSectionStyleWpfTextRendererElement : WpfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tocSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionStyleWpfTextRendererElement(TocSectionStyle tocSectionStyle) : base(tocSectionStyle)
    {
        _tocSectionStyle = tocSectionStyle;
        ClassName = "TocSectionStyle";
    }
}