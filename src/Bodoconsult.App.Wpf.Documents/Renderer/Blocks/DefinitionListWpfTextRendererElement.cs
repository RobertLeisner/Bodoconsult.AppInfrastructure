// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.Text.Documents;
using Paragraph = System.Windows.Documents.Paragraph;
using Table = System.Windows.Documents.Table;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="DefinitionList"/> instances
/// </summary>
public class DefinitionListWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly DefinitionList _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListWpfTextRendererElement(DefinitionList item) : base(item)
    {
        _item = item;
        ClassName = item.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        // Create the Table...
        renderer.Dispatcher.Invoke(() =>
        {
            var table1 = new Table
            {
                Margin = WpfDocumentRendererHelper.NoMarginThickness,
                Padding = WpfDocumentRendererHelper.NoMarginThickness,
                CellSpacing = 0
            };

            // ...and add it to the FlowDocument Blocks collection.
            renderer.CurrentSection.Blocks.Add(table1);

            // Set some global formatting properties for the table.
            //table1.CellSpacing = 10;
            table1.Background = Brushes.White;


            var column = new TableColumn
            {
                Background = Brushes.White,
                Width = new GridLength(1, GridUnitType.Star)
            };

            table1.Columns.Add(column);

            column = new TableColumn
            {
                Background = Brushes.White,
                Width = new GridLength(4, GridUnitType.Star)
            };

            table1.Columns.Add(column);

            table1.RowGroups.Add(new TableRowGroup());

            var rowGroup = table1.RowGroups[0];

            foreach (var item in _item.ChildBlocks)
            {
                var row = new TableRow();
                rowGroup.Rows.Add(row);

                var dt = (DefinitionListTerm)item;

                var p = new Paragraph();
                var style = (Style)renderer.StyleSet["DefinitionListTermStyle"];
                p.Style = style;

                WpfDocumentRendererHelper.RenderBlockInlinesToWpf(renderer, dt.ChildInlines, p);

                // Column 1
                var cell = new TableCell(p)
                {
                    Padding = WpfDocumentRendererHelper.NoMarginThickness
                };
                row.Cells.Add(cell);

                // Column 2
                cell = new TableCell
                {
                    Padding = WpfDocumentRendererHelper.NoMarginThickness
                };
                WpfDocumentRendererHelper.RenderBlockChildsToWpf(renderer, dt.DefinitionListItems, cell);
                row.Cells.Add(cell);

            }
        });
    }
}