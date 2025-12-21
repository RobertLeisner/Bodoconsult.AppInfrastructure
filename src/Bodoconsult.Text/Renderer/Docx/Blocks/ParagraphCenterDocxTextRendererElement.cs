// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="ParagraphCenter"/> instances
/// </summary>
public class ParagraphCenterDocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly ParagraphCenter _paragraphCenter;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterDocxTextRendererElement(ParagraphCenter paragraphCenter) : base(paragraphCenter)
    {
        _paragraphCenter = paragraphCenter;
        ClassName = paragraphCenter.StyleName;
    }
}