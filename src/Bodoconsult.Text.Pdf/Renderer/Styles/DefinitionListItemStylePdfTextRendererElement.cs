﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// PDF rendering element for <see cref="DefinitionListItemStyle"/> instances
/// </summary>
public class DefinitionListItemStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly DefinitionListItemStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItemStylePdfTextRendererElement(DefinitionListItemStyle style) : base(style)
    {
        _style = style;
        ClassName = "DefinitionListItemStyle";
        AdditionalCss.Add("grid-column-start: 2;");
    }
}