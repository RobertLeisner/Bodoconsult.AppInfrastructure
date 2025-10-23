// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ParagraphRightStyle"/> instances
/// </summary>
public class ParagraphRightStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _paragraphRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRightStyleRtfTextRendererElement(ParagraphRightStyle paragraphRightStyle) : base(paragraphRightStyle)
    {
        _paragraphRightStyle = paragraphRightStyle;
        ClassName = "ParagraphRightStyle";
    }
}