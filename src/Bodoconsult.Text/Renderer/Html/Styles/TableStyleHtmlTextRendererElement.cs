// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Extensions;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TableStyle"/> instances
/// </summary>
public class TableStyleHtmlTextRendererElement : HtmlStyleTextRendererElementBase
{
    private readonly TableStyle _tableStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableStyleHtmlTextRendererElement(TableStyle tableStyle)
    {
        _tableStyle = tableStyle;
        ClassName = "TableStyle";
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        var sb = new StringBuilder();

        sb.AppendLine($".{_tableStyle.GetType().Name}");
        sb.AppendLine("{");

        sb.AppendLine("border-collapse: collapse;");
        sb.AppendLine($"border-spacing: {MeasurementHelper.GetPxFromPt(_tableStyle.BorderSpacing)}px;");

        sb.AppendLine($"margin-top: {_tableStyle.Margins.Top.ToString("0.00")}pt;");
        sb.AppendLine($"margin-bottom: {_tableStyle.Margins.Bottom.FromCmToPoint().ToString("0")}pt;");
        sb.AppendLine("margin-left: auto;");
        sb.AppendLine("margin-right: auto;");

        sb.AppendLine("}");
        renderer.Content.Append(sb);
    }
}