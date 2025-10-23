// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="Toc1Style"/> instances
/// </summary>
public class Toc1StyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _toc1Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1StyleRtfTextRendererElement(Toc1Style toc1Style) : base(toc1Style)
    {
        _toc1Style = toc1Style;
        ClassName = "Toc1Style";
    }
}