// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="Heading5Style"/> instances
/// </summary>
public class Heading5StyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _heading5Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading5StyleRtfTextRendererElement(Heading5Style heading5Style) : base(heading5Style)
    {
        _heading5Style = heading5Style;
        ClassName = "Heading5Style";
    }
}