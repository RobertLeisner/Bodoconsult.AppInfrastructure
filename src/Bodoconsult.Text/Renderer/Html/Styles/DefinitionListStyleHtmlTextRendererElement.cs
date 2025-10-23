// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using System.Text;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="DefinitionListStyle"/> instances
/// </summary>
public class DefinitionListStyleHtmlTextRendererElement : ITextRendererElement
{
    private readonly DefinitionListStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListStyleHtmlTextRendererElement(DefinitionListStyle style)
    {
        _style = style;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        var sb = new StringBuilder();

        sb.AppendLine($".{_style.GetType().Name}");
        sb.AppendLine("{");
        sb.AppendLine("     display: grid;\r\n     grid-template-columns: 15% auto;");
        
        sb.AppendLine("}");
        renderer.Content.Append(sb);
    }
}