// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="Heading2Style"/> instances
/// </summary>
public class Heading2StyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _heading2Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2StyleRtfTextRendererElement(Heading2Style heading2Style) : base(heading2Style)
    {
        _heading2Style = heading2Style;
        ClassName = "Heading2Style";
    }
}