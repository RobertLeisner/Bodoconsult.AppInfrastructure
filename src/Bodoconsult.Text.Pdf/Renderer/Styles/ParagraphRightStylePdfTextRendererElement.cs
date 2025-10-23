﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// PDF rendering element for <see cref="ParagraphRightStyle"/> instances
/// </summary>
public class ParagraphRightStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphRightStyle _paragraphRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRightStylePdfTextRendererElement(ParagraphRightStyle paragraphRightStyle) : base(paragraphRightStyle)
    {
        _paragraphRightStyle = paragraphRightStyle;
        ClassName = "ParagraphRightStyle";
    }
}