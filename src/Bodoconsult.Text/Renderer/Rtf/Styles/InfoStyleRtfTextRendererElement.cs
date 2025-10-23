// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="InfoStyle"/> instances
/// </summary>
public class InfoStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _infoStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public InfoStyleRtfTextRendererElement(InfoStyle infoStyle) : base(infoStyle)
    {
        _infoStyle = infoStyle;
        ClassName = "InfoStyle";
    }
}