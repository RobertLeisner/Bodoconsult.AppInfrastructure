// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ParagraphCenterStyle"/> instances
/// </summary>
public class ParagraphCenterStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _paragraphCenterStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterStyleRtfTextRendererElement(ParagraphCenterStyle paragraphCenterStyle) : base(paragraphCenterStyle)
    {
        _paragraphCenterStyle = paragraphCenterStyle;
        ClassName = "ParagraphCenterStyle";
    }
}