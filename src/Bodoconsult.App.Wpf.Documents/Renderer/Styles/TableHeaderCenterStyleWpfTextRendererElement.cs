// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TableHeaderCenterStyle"/> instances
/// </summary>
public class TableHeaderCenterStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderCenterStyle _tableHeaderStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderCenterStyleWpfTextRendererElement(TableHeaderCenterStyle tableHeaderStyle): base(tableHeaderStyle)
    {
        _tableHeaderStyle = tableHeaderStyle;
        ClassName = "TableCenterHeaderStyle";
    }
}