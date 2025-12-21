// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="Heading1Style"/> instances
/// </summary>
public class Heading1StyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly Heading1Style _heading1Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading1StyleDocxTextRendererElement(Heading1Style heading1Style) : base(heading1Style)
    {
        _heading1Style = heading1Style;
        ClassName = "Heading1Style";
    }
}