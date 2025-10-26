// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;
using Bodoconsult.Text.Documents;
using SolidColorBrush = System.Windows.Media.SolidColorBrush;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="ListItem"/> instances
/// </summary>
public class ListItemWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly ListItem _listItem;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ListItemWpfTextRendererElement(ListItem listItem) : base(listItem)
    {
        _listItem = listItem;
        ClassName = listItem.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        // Do nothing
    }
}