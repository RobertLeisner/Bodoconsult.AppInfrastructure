// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ParagraphStyle"/> instances
/// </summary>
public class ParagraphStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _paragraphStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphStyleRtfTextRendererElement(ParagraphStyle paragraphStyle) : base(paragraphStyle)
    {
        _paragraphStyle = paragraphStyle;
        ClassName = "ParagraphStyle";
    }
}