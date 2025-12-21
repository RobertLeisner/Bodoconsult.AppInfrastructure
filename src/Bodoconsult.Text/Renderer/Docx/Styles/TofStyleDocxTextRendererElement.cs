// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TofStyle"/> instances
/// </summary>
public class TofStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly TofStyle _tofStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofStyleDocxTextRendererElement(TofStyle tofStyle) : base(tofStyle)
    {
        _tofStyle = tofStyle;
        ClassName = "TofStyle";
    }
}