// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ErrorStyle"/> instances
/// </summary>
public class ErrorStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _errorStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ErrorStyleRtfTextRendererElement(ErrorStyle errorStyle) : base(errorStyle)
    {
        _errorStyle = errorStyle;
        ClassName = "ErrorStyle";
    }
}