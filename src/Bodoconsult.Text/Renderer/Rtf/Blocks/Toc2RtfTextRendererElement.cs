// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Toc2"/> instances
/// </summary>
public class Toc2RtfTextRendererElement : ToxRtfTextRendererElementBase
{
    private readonly Toc2 _toc2;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc2RtfTextRendererElement(Toc2 toc2) : base(toc2)
    {
        _toc2 = toc2;
        ClassName = toc2.StyleName;
    }
}