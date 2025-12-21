// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TableHeaderCenterStyle"/> instances
/// </summary>
public class TableHeaderCenterStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderCenterStyle _tableHeaderStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderCenterStyleDocxTextRendererElement(TableHeaderCenterStyle tableHeaderStyle): base(tableHeaderStyle)
    {
        _tableHeaderStyle = tableHeaderStyle;
        ClassName = "TableCenterHeaderStyle";
    }
}