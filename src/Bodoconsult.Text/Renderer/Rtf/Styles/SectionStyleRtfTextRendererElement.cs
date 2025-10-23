// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="SectionStyle"/> instances
/// </summary>
public class SectionStyleRtfTextRendererElement : RtfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _sectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionStyleRtfTextRendererElement(SectionStyle sectionStyle) : base(sectionStyle)
    {
        _sectionStyle = sectionStyle;
        ClassName = "SectionStyle";
    }
}