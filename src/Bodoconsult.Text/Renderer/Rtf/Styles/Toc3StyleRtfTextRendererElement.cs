// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="Toc3Style"/> instances
/// </summary>
public class Toc3StyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _toc3Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc3StyleRtfTextRendererElement(Toc3Style toc3Style) : base(toc3Style)
    {
        _toc3Style = toc3Style;
        ClassName = "Toc3Style";
    }
}