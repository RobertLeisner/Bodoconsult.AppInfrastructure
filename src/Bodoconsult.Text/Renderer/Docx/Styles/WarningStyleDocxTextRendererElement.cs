// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="WarningStyle"/> instances
/// </summary>
public class WarningStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly WarningStyle _warningStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningStyleDocxTextRendererElement(WarningStyle warningStyle) : base(warningStyle)
    {
        _warningStyle = warningStyle;
        ClassName = "WarningStyle";
    }
}

