// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="Heading3Style"/> instances
/// </summary>
public class Heading3StyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _heading3Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3StyleRtfTextRendererElement(Heading3Style heading3Style) : base(heading3Style)
    {
        _heading3Style = heading3Style;
        ClassName = "Heading3Style";
    }
}