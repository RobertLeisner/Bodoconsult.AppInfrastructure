﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="WarningStyle"/> instances
/// </summary>
public class WarningStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly WarningStyle _warningStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningStylePdfTextRendererElement(WarningStyle warningStyle) : base(warningStyle)
    {
        _warningStyle = warningStyle;
        ClassName = "WarningStyle";
    }
}

