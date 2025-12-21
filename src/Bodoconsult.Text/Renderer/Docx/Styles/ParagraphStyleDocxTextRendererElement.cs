// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="ParagraphStyle"/> instances
/// </summary>
public class ParagraphStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyle _paragraphStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphStyleDocxTextRendererElement(ParagraphStyle paragraphStyle) : base(paragraphStyle)
    {
        _paragraphStyle = paragraphStyle;
        ClassName = "ParagraphStyle";
    }
}