// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="WarningStyle"/> instances
/// </summary>
public class WarningStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _warningStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningStyleRtfTextRendererElement(WarningStyle warningStyle) : base(warningStyle)
    {
        _warningStyle = warningStyle;
        ClassName = "WarningStyle";
    }
}