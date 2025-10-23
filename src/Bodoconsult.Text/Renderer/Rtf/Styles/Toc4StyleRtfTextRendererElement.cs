// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="Toc4Style"/> instances
/// </summary>
public class Toc4StyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _toc4Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc4StyleRtfTextRendererElement(Toc4Style toc4Style) : base(toc4Style)
    {
        _toc4Style = toc4Style;
        ClassName = "Toc4Style";
    }
}