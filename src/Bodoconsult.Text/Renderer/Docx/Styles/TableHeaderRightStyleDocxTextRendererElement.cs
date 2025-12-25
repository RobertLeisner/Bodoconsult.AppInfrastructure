// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TableHeaderRightStyle"/> instances
/// </summary>
public class TableHeaderRightStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderRightStyle _tableHeaderRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderRightStyleDocxTextRendererElement(TableHeaderRightStyle tableHeaderRightStyle) : base(tableHeaderRightStyle)
    {
        _tableHeaderRightStyle = tableHeaderRightStyle;
        ClassName = "TableHeaderRightStyle";
    }
}