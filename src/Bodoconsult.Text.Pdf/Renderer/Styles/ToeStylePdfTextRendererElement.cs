// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="ToeStyle"/> instances
/// </summary>
public class ToeStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly ToeStyle _toeStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeStylePdfTextRendererElement(ToeStyle toeStyle) : base(toeStyle)
    {
        _toeStyle = toeStyle;
        ClassName = "TotStyle";
    }
}