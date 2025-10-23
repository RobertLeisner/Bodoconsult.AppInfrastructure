// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TofSectionStyle"/> instances
/// </summary>
public class TofSectionStylePdfTextRendererElement : PdfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tofSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionStylePdfTextRendererElement(TofSectionStyle tofSectionStyle) : base(tofSectionStyle)
    {
        _tofSectionStyle = tofSectionStyle;
        ClassName = "TofSectionStyle";
    }
}