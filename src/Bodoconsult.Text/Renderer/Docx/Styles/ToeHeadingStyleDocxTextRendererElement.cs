// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TocHeadingStyle"/> instances
/// </summary>
public class ToeHeadingStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly ToeHeadingStyle _toeHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeHeadingStyleDocxTextRendererElement(ToeHeadingStyle toeHeadingStyle) : base(toeHeadingStyle)
    {
        _toeHeadingStyle = toeHeadingStyle;
        ClassName = "ToeHeadingStyle";
    }
}