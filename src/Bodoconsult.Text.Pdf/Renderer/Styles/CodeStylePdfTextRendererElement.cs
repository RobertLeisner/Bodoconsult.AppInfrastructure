// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="CodeStyle"/> instances
/// </summary>
public class CodeStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly CodeStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CodeStylePdfTextRendererElement(CodeStyle style) : base(style)
    {
        _style = style;
        ClassName = "CodeStyle";
    }
}