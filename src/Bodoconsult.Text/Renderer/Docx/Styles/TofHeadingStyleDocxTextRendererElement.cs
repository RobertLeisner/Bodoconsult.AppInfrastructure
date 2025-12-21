// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TofHeadingStyle"/> instances
/// </summary>
public class TofHeadingStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly TofHeadingStyle _tofHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofHeadingStyleDocxTextRendererElement(TofHeadingStyle tofHeadingStyle) : base(tofHeadingStyle)
    {
        _tofHeadingStyle = tofHeadingStyle;
        ClassName = "TofHeadingStyle";
    }
}