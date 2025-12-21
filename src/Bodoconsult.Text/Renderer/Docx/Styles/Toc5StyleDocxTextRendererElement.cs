// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="Toc5Style"/> instances
/// </summary>
public class Toc5StyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly Toc5Style _toc5Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc5StyleDocxTextRendererElement(Toc5Style toc5Style) : base(toc5Style)
    {
        _toc5Style = toc5Style;
        ClassName = "Toc5Style";
    }
}