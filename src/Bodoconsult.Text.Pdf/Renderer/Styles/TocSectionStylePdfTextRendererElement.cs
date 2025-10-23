// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TocSectionStyle"/> instances
/// </summary>
public class TocSectionStylePdfTextRendererElement : PdfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tocSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionStylePdfTextRendererElement(TocSectionStyle tocSectionStyle) : base(tocSectionStyle)
    {
        _tocSectionStyle = tocSectionStyle;
        ClassName = "TocSectionStyle";
    }
}