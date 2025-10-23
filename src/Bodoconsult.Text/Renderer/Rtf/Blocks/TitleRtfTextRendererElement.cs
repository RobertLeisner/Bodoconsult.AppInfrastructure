// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Title"/> instances
/// </summary>
public class TitleRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Title _title;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TitleRtfTextRendererElement(Title title) : base(title)
    {
        _title = title;
        ClassName = title.StyleName;
    }
}