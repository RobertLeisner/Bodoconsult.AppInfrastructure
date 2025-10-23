// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ToeSectionStyle"/> instances
/// </summary>
public class ToeSectionStyleRtfTextRendererElement : RtfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _toeSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSectionStyleRtfTextRendererElement(ToeSectionStyle toeSectionStyle) : base(toeSectionStyle)
    {
        _toeSectionStyle = toeSectionStyle;
        ClassName = "ToeSectionStyle";
    }
}