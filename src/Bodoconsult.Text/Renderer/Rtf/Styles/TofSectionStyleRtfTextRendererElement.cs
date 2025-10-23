// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TofSectionStyle"/> instances
/// </summary>
public class TofSectionStyleRtfTextRendererElement : RtfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tofSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionStyleRtfTextRendererElement(TofSectionStyle tofSectionStyle) : base(tofSectionStyle)
    {
        _tofSectionStyle = tofSectionStyle;
        ClassName = "TofSectionStyle";
    }
}