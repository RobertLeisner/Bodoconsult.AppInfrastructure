// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="ParagraphCenter"/> instances
/// </summary>
public class ParagraphCenterRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly ParagraphCenter _paragraphCenter;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterRtfTextRendererElement(ParagraphCenter paragraphCenter) : base(paragraphCenter)
    {
        _paragraphCenter = paragraphCenter;
        ClassName = paragraphCenter.StyleName;
    }
}