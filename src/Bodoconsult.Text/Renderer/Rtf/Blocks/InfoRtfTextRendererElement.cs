// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Info"/> instances
/// </summary>
public class InfoRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Info _info;

    /// <summary>
    /// Default ctor
    /// </summary>
    public InfoRtfTextRendererElement(Info info) : base(info)
    {
        _info = info;
        ClassName = info.StyleName;
    }
}