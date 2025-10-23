// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="ParagraphRight"/> instances
/// </summary>
public class ParagraphRightRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly ParagraphRight _paragraphRight;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRightRtfTextRendererElement(ParagraphRight paragraphRight) : base(paragraphRight)
    {
        _paragraphRight = paragraphRight;
        ClassName = paragraphRight.StyleName;
    }
}