// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TocSectionStyle"/> instances
/// </summary>
public class TocSectionStyleDocxTextRendererElement : DocxPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tocSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionStyleDocxTextRendererElement(TocSectionStyle tocSectionStyle) : base(tocSectionStyle)
    {
        _tocSectionStyle = tocSectionStyle;
        ClassName = "TocSectionStyle";
    }
}