﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// PDF rendering element for <see cref="ToeSectionStyle"/> instances
/// </summary>
public class ToeSectionStylePdfTextRendererElement : PdfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _toeSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSectionStylePdfTextRendererElement(ToeSectionStyle toeSectionStyle) : base(toeSectionStyle)
    {
        _toeSectionStyle = toeSectionStyle;
        ClassName = "ToeSectionStyle";
    }
}