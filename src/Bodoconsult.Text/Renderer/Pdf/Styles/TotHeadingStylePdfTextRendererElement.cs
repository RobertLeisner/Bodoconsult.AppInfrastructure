// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Pdf.Styles;

/// <summary>
/// PDF rendering element for <see cref="TotHeadingStyle"/> instances
/// </summary>
public class TotHeadingStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TotHeadingStyle _totHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotHeadingStylePdfTextRendererElement(TotHeadingStyle totHeadingStyle) : base(totHeadingStyle)
    {
        _totHeadingStyle = totHeadingStyle;
        ClassName = "TotHeadingStyle";
    }
}