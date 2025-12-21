// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="ParagraphRight"/> instances
/// </summary>
public class ParagraphRightDocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly ParagraphRight _paragraphRight;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRightDocxTextRendererElement(ParagraphRight paragraphRight) : base(paragraphRight)
    {
        _paragraphRight = paragraphRight;
        ClassName = paragraphRight.StyleName;
    }
}