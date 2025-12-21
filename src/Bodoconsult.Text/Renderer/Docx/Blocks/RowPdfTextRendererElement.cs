// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Row"/> instances
/// </summary>
public class RowDocxTextRendererElement : DocxTextRendererElementBase
{
    private readonly Row _row;

    /// <summary>
    /// Default ctor
    /// </summary>
    public RowDocxTextRendererElement(Row row) : base(row)
    {
        _row = row;
        ClassName = "RowStyle";
    }
}