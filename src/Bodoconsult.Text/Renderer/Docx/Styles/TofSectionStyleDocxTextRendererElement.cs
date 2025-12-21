// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TofSectionStyle"/> instances
/// </summary>
public class TofSectionStyleDocxTextRendererElement : DocxPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tofSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionStyleDocxTextRendererElement(TofSectionStyle tofSectionStyle) : base(tofSectionStyle)
    {
        _tofSectionStyle = tofSectionStyle;
        ClassName = "TofSectionStyle";
    }
}