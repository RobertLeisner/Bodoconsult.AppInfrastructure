// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TitleStyle"/> instances
/// </summary>
public class TitleStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _titleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TitleStyleRtfTextRendererElement(TitleStyle titleStyle) : base(titleStyle)
    {
        _titleStyle = titleStyle;
        ClassName = "TitleStyle";
    }
}