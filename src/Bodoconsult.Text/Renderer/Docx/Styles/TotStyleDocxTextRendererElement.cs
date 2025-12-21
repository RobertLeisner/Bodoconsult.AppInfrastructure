// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TotStyle"/> instances
/// </summary>
public class TotStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly TotStyle _totStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotStyleDocxTextRendererElement(TotStyle totStyle) : base(totStyle)
    {
        _totStyle = totStyle;
        ClassName = "TotStyle";
    }
}