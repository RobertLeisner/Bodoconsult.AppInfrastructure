// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="FigureStyle"/> instances
/// </summary>
public class FigureStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _figureStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FigureStyleRtfTextRendererElement(FigureStyle figureStyle) : base(figureStyle)
    {
        _figureStyle = figureStyle;
        ClassName = "FigureStyle";
    }
}