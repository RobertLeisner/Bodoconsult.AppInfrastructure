// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Tot"/> instances
/// </summary>
public class TotRtfTextRendererElement : ToxRtfTextRendererElementBase
{
    private readonly Tot _tot;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotRtfTextRendererElement(Tot tot) : base(tot)
    {
        _tot = tot;
        ClassName = tot.StyleName;
    }
}