// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TotHeadingStyle"/> instances
/// </summary>
public class TotHeadingStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly TotHeadingStyle _totHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotHeadingStyleDocxTextRendererElement(TotHeadingStyle totHeadingStyle) : base(totHeadingStyle)
    {
        _totHeadingStyle = totHeadingStyle;
        ClassName = "TotHeadingStyle";
    }
}