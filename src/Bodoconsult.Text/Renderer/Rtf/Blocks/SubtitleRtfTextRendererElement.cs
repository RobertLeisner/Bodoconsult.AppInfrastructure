// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Subtitle"/> instances
/// </summary>
public class SubtitleRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Subtitle _subtitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitleRtfTextRendererElement(Subtitle subtitle) : base(subtitle)
    {
        _subtitle = subtitle;
        ClassName = subtitle.StyleName;
    }
}