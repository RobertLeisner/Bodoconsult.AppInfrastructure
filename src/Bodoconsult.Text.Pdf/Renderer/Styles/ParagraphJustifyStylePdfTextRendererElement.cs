﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// PDF rendering element for <see cref="ParagraphJustifyStyle"/> instances
/// </summary>
public class ParagraphJustifyStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphJustifyStyle _paragraphJustifyStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphJustifyStylePdfTextRendererElement(ParagraphJustifyStyle paragraphJustifyStyle) : base(paragraphJustifyStyle)
    {
        _paragraphJustifyStyle = paragraphJustifyStyle;
        ClassName = "ParagraphJustifyStyle";
    }
}