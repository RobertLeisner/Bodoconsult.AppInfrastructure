// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Heading3"/> instances
/// </summary>
public class Heading3RtfTextRendererElement : HeadingBaseRtfTextRendererElement
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3RtfTextRendererElement(Heading3 heading3) : base(heading3)
    {
        ClassName = heading3.StyleName;
    }
}