// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="SectionStyle"/> instances
/// </summary>
public class SectionStyleWpfTextRendererElement : WpfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _sectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionStyleWpfTextRendererElement(SectionStyle sectionStyle) : base(sectionStyle)
    {
        _sectionStyle = sectionStyle;
        ClassName = "SectionStyle";
    }
}