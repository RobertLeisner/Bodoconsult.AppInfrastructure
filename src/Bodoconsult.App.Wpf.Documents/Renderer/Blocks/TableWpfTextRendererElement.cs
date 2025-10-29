// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.


using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.Text.Documents;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.Text.Helpers;
using SolidColorBrush = System.Windows.Media.SolidColorBrush;
using Table = Bodoconsult.Text.Documents.Table;
using Thickness = System.Windows.Thickness;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Bodoconsult.Text.Documents.Table"/> instances
/// </summary>
public class TableWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly Table _table;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableWpfTextRendererElement(Table table) : base(table)
    {
        _table = table;
        ClassName = "TableStyle";
    }


    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        var tableStyle = (TableStyle)renderer.Styleset.FindStyle("TableStyle");

        // Create the Table...
        renderer.Dispatcher.Invoke(() =>
        {
            var table1 = new System.Windows.Documents.Table
            {
                Margin = new Thickness(0, MeasurementHelper.GetDiuFromPoint(tableStyle.Margins.Top), 0, MeasurementHelper.GetDiuFromPoint(tableStyle.Margins.Bottom)),
                Padding = WpfDocumentRendererHelper.NoMarginThickness,
                CellSpacing = 0
            };

            // ...and add it to the FlowDocument Blocks collection.
            renderer.CurrentSection.Blocks.Add(table1);

            // Set some global formatting properties for the table.
            //table1.CellSpacing = 10;
            table1.Background = Brushes.White;

            // Columns
            var rowGroup = CreateColumns(table1);


            // Header row
            CreateHeaderRow(renderer, rowGroup);

            // Content
            foreach (var tableRow in _table.Rows)
            {
                CreateDataRow(renderer, rowGroup, tableRow);
            }
        });
    }

    private TableRowGroup CreateColumns(System.Windows.Documents.Table table)
    {
        foreach (var tableColumn in _table.Columns)
        {
            var column = new TableColumn
            {
                Background = Brushes.White,
                Width = new GridLength(1, GridUnitType.Star)
            };

            table.Columns.Add(column);
        }

        table.RowGroups.Add(new TableRowGroup());

        var rowGroup = table.RowGroups[0];
        return rowGroup;
    }

    private void CreateHeaderRow(WpfTextDocumentRenderer renderer, TableRowGroup rowGroup)
    {
        var row = new TableRow();
        rowGroup.Rows.Add(row);
        foreach (var tableColumn in _table.Columns)
        {
            var alignment = DocumentRendererHelper.GetAlignment(tableColumn.DataType);

            var p = new System.Windows.Documents.Paragraph(new Run(tableColumn.Name));
            var style = (Style)renderer.StyleSet[$"TableHeader{alignment}Style"];
            p.Style = style;

            var cell = new TableCell(p)
            {
                Padding = WpfDocumentRendererHelper.SmallPaddingThickness,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1, 1, 1, 1)
            };
            row.Cells.Add(cell);

        }
    }

    private static void CreateDataRow(WpfTextDocumentRenderer renderer, TableRowGroup rowGroup, Row tableRow)
    {
        var row = new TableRow();
        rowGroup.Rows.Add(row);
        foreach (var dataCell in tableRow.Cells)
        {
            var alignment = DocumentRendererHelper.GetAlignment(dataCell.Column.DataType);

            var p = new System.Windows.Documents.Paragraph();
            var style = (Style)renderer.StyleSet[$"Cell{alignment}Style"];
            p.Style = style;

            WpfDocumentRendererHelper.RenderBlockInlinesToWpf(renderer, dataCell.ChildInlines, p);

            var cell = new TableCell(p)
            {
                Padding = WpfDocumentRendererHelper.SmallPaddingThickness,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1, 1, 1, 1)
            };
            row.Cells.Add(cell);

        }
    }
}