// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TableStyle"/> instances
/// </summary>
public class TableStyleWpfTextRendererElement : WpfStyleTextRendererElementBase
{
    private readonly TableStyle _tableStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableStyleWpfTextRendererElement(TableStyle tableStyle)
    {
        _tableStyle = tableStyle;
        ClassName = "TableStyle";
    }
}