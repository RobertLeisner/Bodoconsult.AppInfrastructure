// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="SectionTitleStyle"/> instances
/// </summary>
public class SectionTitleStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _sectionTitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleStyleRtfTextRendererElement(SectionTitleStyle sectionTitleStyle) : base(sectionTitleStyle)
    {
        _sectionTitleStyle = sectionTitleStyle;
        ClassName = "SectionTitleStyle";
    }
}