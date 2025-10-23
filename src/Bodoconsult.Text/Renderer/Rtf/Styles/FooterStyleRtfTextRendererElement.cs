// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="FooterStyle"/> instances
/// </summary>
public class FooterStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FooterStyleRtfTextRendererElement(FooterStyle style) : base(style)
    {
        _style = style;
        ClassName = "FooterStyle";
    }
}