// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Heading2"/> instances
/// </summary>
public class Heading2RtfTextRendererElement : HeadingBaseRtfTextRendererElement
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2RtfTextRendererElement(Heading2 heading2) : base(heading2)
    {
        ClassName = heading2.StyleName;
    }
}