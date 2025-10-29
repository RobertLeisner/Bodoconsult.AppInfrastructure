// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.Text.Documents;
using System.Windows;
using System.Windows.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="DefinitionListItem"/> instances
/// </summary>
public class DefinitionListItemWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly DefinitionListItem _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItemWpfTextRendererElement(DefinitionListItem item) : base(item)
    {
        _item = item;
        ClassName = item.StyleName;
    }

    /// <summary>
    /// Render the definition list item to a cell
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="cell">Current cell to render the content in</param>
    /// <exception cref="NotImplementedException"></exception>
    public void RenderIt(WpfTextDocumentRenderer renderer, TableCell cell)
    {
        renderer.Dispatcher.Invoke(() =>
        {
            var p = new System.Windows.Documents.Paragraph();
            var style = (Style)renderer.StyleSet["DefinitionListItemStyle"];
            p.Style = style;
            WpfDocumentRendererHelper.RenderBlockInlinesToWpf(renderer, _item.ChildInlines, p);
            cell.Blocks.Add(p);
        });
    }
}