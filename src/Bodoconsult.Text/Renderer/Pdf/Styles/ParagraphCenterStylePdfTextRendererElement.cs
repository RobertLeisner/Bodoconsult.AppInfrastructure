// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Pdf.Styles;

/// <summary>
/// PDF rendering element for <see cref="ParagraphCenterStyle"/> instances
/// </summary>
public class ParagraphCenterStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphCenterStyle _paragraphCenterStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterStylePdfTextRendererElement(ParagraphCenterStyle paragraphCenterStyle) : base(paragraphCenterStyle)
    {
        _paragraphCenterStyle = paragraphCenterStyle;
        ClassName = "ParagraphCenterStyle";
    }
}