// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="ToeSectionStyle"/> instances
/// </summary>
public class ToeSectionStyleWpfTextRendererElement : WpfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _toeSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSectionStyleWpfTextRendererElement(ToeSectionStyle toeSectionStyle) : base(toeSectionStyle)
    {
        _toeSectionStyle = toeSectionStyle;
        ClassName = "ToeSectionStyle";
    }
}