// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Column"/> instances
/// </summary>
public class ColumnHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Column _column;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ColumnHtmlTextRendererElement(Column column) : base(column)
    {
        _column = column;
        ClassName = "ColumnStyle";
    }
}