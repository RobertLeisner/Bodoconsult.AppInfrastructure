// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Column"/> instances
/// </summary>
public class ColumnDocxTextRendererElement : DocxTextRendererElementBase
{
    private readonly Column _column;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ColumnDocxTextRendererElement(Column column) : base(column)
    {
        _column = column;
        ClassName = "ColumnStyle";
    }
}