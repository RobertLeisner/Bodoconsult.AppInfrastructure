// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Pdf.Styles;

/// <summary>
/// PDF rendering element for <see cref="Heading3Style"/> instances
/// </summary>
public class Heading3StylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly Heading3Style _heading3Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3StylePdfTextRendererElement(Heading3Style heading3Style) : base(heading3Style)
    {
        _heading3Style = heading3Style;
        ClassName = "Heading3Style";
    }
}