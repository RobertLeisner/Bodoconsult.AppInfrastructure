// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="Toc5Style"/> instances
/// </summary>
public class Toc5StylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly Toc5Style _toc5Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc5StylePdfTextRendererElement(Toc5Style toc5Style) : base(toc5Style)
    {
        _toc5Style = toc5Style;
        ClassName = "Toc5Style";
    }
}