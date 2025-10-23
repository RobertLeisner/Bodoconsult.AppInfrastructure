// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="Heading4Style"/> instances
/// </summary>
public class Heading4StyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _heading4Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading4StyleRtfTextRendererElement(Heading4Style heading4Style) : base(heading4Style)
    {
        _heading4Style = heading4Style;
        ClassName = "Heading4Style";
    }
}