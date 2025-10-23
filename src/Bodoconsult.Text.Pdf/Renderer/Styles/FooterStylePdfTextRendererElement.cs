// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="FooterStyle"/> instances
/// </summary>
public class FooterStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly FooterStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FooterStylePdfTextRendererElement(FooterStyle style) : base(style)
    {
        _style = style;
        ClassName = "FooterStyle";
    }
}