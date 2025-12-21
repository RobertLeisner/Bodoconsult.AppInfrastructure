// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="CodeStyle"/> instances
/// </summary>
public class CodeStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly CodeStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CodeStyleDocxTextRendererElement(CodeStyle style) : base(style)
    {
        _style = style;
        ClassName = "CodeStyle";
    }
}