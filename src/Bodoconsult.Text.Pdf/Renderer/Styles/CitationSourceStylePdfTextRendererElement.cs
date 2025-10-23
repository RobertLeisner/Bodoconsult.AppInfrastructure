// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="CitationSourceStyle"/> instances
/// </summary>
public class CitationSourceStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly CitationSourceStyle _citationSourceStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationSourceStylePdfTextRendererElement(CitationSourceStyle citationSourceStyle) : base(citationSourceStyle)
    {
        _citationSourceStyle = citationSourceStyle;
        ClassName = "CitationSourceStyle";
    }
}