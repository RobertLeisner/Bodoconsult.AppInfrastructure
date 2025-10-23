// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TocSectionStyle"/> instances
/// </summary>
public class TocSectionStyleRtfTextRendererElement : RtfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tocSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionStyleRtfTextRendererElement(TocSectionStyle tocSectionStyle) : base(tocSectionStyle)
    {
        _tocSectionStyle = tocSectionStyle;
        ClassName = "TocSectionStyle";
    }
}