// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Warning"/> instances
/// </summary>
public class WarningRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Warning _warning;

    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningRtfTextRendererElement(Warning warning) : base(warning)
    {
        _warning = warning;
        ClassName = warning.StyleName;
    }
}