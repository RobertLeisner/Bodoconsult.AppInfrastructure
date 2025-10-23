// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TofStyle"/> instances
/// </summary>
public class TofStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TofStyle _tofStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofStylePdfTextRendererElement(TofStyle tofStyle) : base(tofStyle)
    {
        _tofStyle = tofStyle;
        ClassName = "TofStyle";
    }
}