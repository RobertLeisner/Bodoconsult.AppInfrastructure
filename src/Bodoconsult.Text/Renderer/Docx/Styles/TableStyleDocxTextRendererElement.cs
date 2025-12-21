// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TableStyle"/> instances
/// </summary>
public class TableStyleDocxTextRendererElement : DocxStyleTextRendererElementBase
{
    private readonly TableStyle _tableStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableStyleDocxTextRendererElement(TableStyle tableStyle)
    {
        _tableStyle = tableStyle;
        ClassName = "TableStyle";
    }
}