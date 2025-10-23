// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Paragraph"/> instances
/// </summary>
public class ParagraphRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Paragraph _paragraph;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRtfTextRendererElement(Paragraph paragraph) : base(paragraph)
    {
        _paragraph = paragraph;
        ClassName = paragraph.StyleName;
    }
}