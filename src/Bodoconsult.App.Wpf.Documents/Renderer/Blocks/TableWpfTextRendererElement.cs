// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.


using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Table"/> instances
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

    }
}