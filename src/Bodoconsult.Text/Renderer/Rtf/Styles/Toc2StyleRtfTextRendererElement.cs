// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="Toc2Style"/> instances
/// </summary>
public class Toc2StyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _toc2Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc2StyleRtfTextRendererElement(Toc2Style toc2Style) : base(toc2Style)
    {
        _toc2Style = toc2Style;
        ClassName = "Toc2Style";
    }
}