// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="DefinitionListTermStyle"/> instances
/// </summary>
public class DefinitionListTermStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly DefinitionListTermStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListTermStyleDocxTextRendererElement(DefinitionListTermStyle style) : base(style)
    {
        _style = style;
        ClassName = "DefinitionListTermStyle";
        AdditionalCss.Add("grid-column-start: 1;");
    }
}