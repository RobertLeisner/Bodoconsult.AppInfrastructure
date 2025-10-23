// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="SubtitleStyle"/> instances
/// </summary>
public class SubtitleStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _subtitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitleStyleRtfTextRendererElement(SubtitleStyle subtitleStyle) : base(subtitleStyle)
    {
        _subtitleStyle = subtitleStyle;
        ClassName = "SubtitleStyle";
    }
}