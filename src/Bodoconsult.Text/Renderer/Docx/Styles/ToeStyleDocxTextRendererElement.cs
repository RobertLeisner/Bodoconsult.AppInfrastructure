// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="ToeStyle"/> instances
/// </summary>
public class ToeStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly ToeStyle _toeStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeStyleDocxTextRendererElement(ToeStyle toeStyle) : base(toeStyle)
    {
        _toeStyle = toeStyle;
        ClassName = "TotStyle";
    }
}