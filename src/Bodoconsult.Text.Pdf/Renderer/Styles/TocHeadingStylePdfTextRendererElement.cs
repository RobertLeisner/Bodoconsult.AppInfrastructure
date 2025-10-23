// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TocHeadingStyle"/> instances
/// </summary>
public class TocHeadingStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TocHeadingStyle _tocHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocHeadingStylePdfTextRendererElement(TocHeadingStyle tocHeadingStyle) : base(tocHeadingStyle)
    {
        _tocHeadingStyle = tocHeadingStyle;
        ClassName = "TocHeadingStyle";
    }
}