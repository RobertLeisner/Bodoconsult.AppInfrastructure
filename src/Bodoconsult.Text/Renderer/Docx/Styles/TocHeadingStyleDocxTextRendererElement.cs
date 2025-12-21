// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TocHeadingStyle"/> instances
/// </summary>
public class TocHeadingStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly TocHeadingStyle _tocHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocHeadingStyleDocxTextRendererElement(TocHeadingStyle tocHeadingStyle) : base(tocHeadingStyle)
    {
        _tocHeadingStyle = tocHeadingStyle;
        ClassName = "TocHeadingStyle";
    }
}