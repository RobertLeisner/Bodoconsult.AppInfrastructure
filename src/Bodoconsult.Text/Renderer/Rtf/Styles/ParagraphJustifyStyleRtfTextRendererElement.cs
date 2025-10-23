// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ParagraphJustifyStyle"/> instances
/// </summary>
public class ParagraphJustifyStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _paragraphJustifyStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphJustifyStyleRtfTextRendererElement(ParagraphJustifyStyle paragraphJustifyStyle) : base(paragraphJustifyStyle)
    {
        _paragraphJustifyStyle = paragraphJustifyStyle;
        ClassName = "ParagraphJustifyStyle";
    }
}