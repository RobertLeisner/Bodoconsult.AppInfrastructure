// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Pdf.Styles;

/// <summary>
/// PDF rendering element for <see cref="Heading4Style"/> instances
/// </summary>
public class Heading4StylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly Heading4Style _heading4Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading4StylePdfTextRendererElement(Heading4Style heading4Style) : base(heading4Style)
    {
        _heading4Style = heading4Style;
        ClassName = "Heading4Style";
    }
}