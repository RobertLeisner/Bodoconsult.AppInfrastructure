﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// PDF rendering element for <see cref="HeaderStyle"/> instances
/// </summary>
public class HeaderStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly HeaderStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public HeaderStylePdfTextRendererElement(HeaderStyle style) : base(style)
    {
        _style = style;
        ClassName = "HeaderStyle";
    }
}