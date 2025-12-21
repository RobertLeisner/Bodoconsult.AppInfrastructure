// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="ColumnStyle"/> instances
/// </summary>
public class ColumnStyleDocxTextRendererElement : DocxStyleTextRendererElementBase
{
    private readonly ColumnStyle _columnStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ColumnStyleDocxTextRendererElement(ColumnStyle columnStyle)
    {
        _columnStyle = columnStyle;
        ClassName = "ColumnStyle";
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        var sb = new StringBuilder();

        sb.AppendLine($".{_columnStyle.GetType().Name}");
        sb.AppendLine("{");

        sb.AppendLine("}");
        renderer.Content.Append(sb);
    }
}