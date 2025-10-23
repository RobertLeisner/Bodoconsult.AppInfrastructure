// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TotSectionStyle"/> instances
/// </summary>
public class TotSectionStyleRtfTextRendererElement : RtfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotSectionStyleRtfTextRendererElement(TotSectionStyle style) : base(style)
    {
        _style = style;
        ClassName = "TotSectionStyle";
    }
}