// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TableLegendStyle"/> instances
/// </summary>
public class TableLegendStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly TableLegendStyle _tableLegendStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableLegendStyleWpfTextRendererElement(TableLegendStyle table) : base(table)
    {
        _tableLegendStyle = table;
        ClassName = "TableLegendStyle";
    }
}