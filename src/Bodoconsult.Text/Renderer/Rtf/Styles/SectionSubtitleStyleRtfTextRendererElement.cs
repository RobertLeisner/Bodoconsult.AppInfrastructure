// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="SectionSubtitleStyle"/> instances
/// </summary>
public class SectionSubtitleStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _sectionSubtitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitleStyleRtfTextRendererElement(SectionSubtitleStyle sectionSubtitleStyle) : base(sectionSubtitleStyle)
    {
        _sectionSubtitleStyle = sectionSubtitleStyle;
        ClassName = "SectionSubtitleStyle";
    }
}