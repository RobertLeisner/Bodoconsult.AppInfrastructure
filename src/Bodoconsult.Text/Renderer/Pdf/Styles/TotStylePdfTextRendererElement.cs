// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Pdf.Styles;

/// <summary>
/// PDF rendering element for <see cref="TotStyle"/> instances
/// </summary>
public class TotStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TotStyle _totStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotStylePdfTextRendererElement(TotStyle totStyle) : base(totStyle)
    {
        _totStyle = totStyle;
        ClassName = "TotStyle";
    }
}