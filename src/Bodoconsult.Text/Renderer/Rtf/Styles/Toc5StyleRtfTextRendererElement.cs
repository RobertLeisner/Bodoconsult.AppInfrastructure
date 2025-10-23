// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="Toc5Style"/> instances
/// </summary>
public class Toc5StyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _toc5Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc5StyleRtfTextRendererElement(Toc5Style toc5Style) : base(toc5Style)
    {
        _toc5Style = toc5Style;
        ClassName = "Toc5Style";
    }
}