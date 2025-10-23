// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Heading1"/> instances
/// </summary>
public class Heading1RtfTextRendererElement : HeadingBaseRtfTextRendererElement
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading1RtfTextRendererElement(Heading1 heading1) : base(heading1)
    {
        ClassName = heading1.StyleName;
    }
}