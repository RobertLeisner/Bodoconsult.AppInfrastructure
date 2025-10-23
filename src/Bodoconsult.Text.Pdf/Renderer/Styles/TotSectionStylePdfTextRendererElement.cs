// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TotSectionStyle"/> instances
/// </summary>
public class TotSectionStylePdfTextRendererElement : PdfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tofSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotSectionStylePdfTextRendererElement(TotSectionStyle tofSectionStyle) : base(tofSectionStyle)
    {
        _tofSectionStyle = tofSectionStyle;
        ClassName = "TotSectionStyle";
    }
}