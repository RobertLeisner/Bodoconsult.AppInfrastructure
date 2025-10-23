// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Generic;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Extensions;
using System.Text;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// Base class for <see cref="ParagraphStyleBase"/> based styles
/// </summary>
public class HtmlParagraphStyleTextRendererElementBase: ITextRendererElement
{
    /// <summary>
    /// HTML tag to use for rendering
    /// </summary>
    protected string TagToUse = "p";

    /// <summary>
    /// Current block to renderer
    /// </summary>
    public ParagraphStyleBase Style { get; private set; }

    /// <summary>
    /// CSS class name
    /// </summary>
    public string ClassName { get; protected set; }

    /// <summary>
    /// Additonal CSS styling tags
    /// </summary>
    public List<string> AdditionalCss { get;  } = new();

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="style">Current paragraph style</param>
    public HtmlParagraphStyleTextRendererElementBase(ParagraphStyleBase style)
    {
        Style = style;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(ITextDocumentRenderer renderer)
    {
        var sb = new StringBuilder();

        sb.AppendLine($".{Style.GetType().Name}");
        sb.AppendLine("{");
        sb.AppendLine($"     font-family: \"{Style.FontName}\";");
        sb.AppendLine($"     font-size: {Style.FontSize.ToString("0")}pt;");

        if (Style.Bold)
        {
            sb.AppendLine($"     font-weight: bold;");
        }

        if (Style.Italic)
        {
            sb.AppendLine($"     font-style: italic;");
        }

        sb.AppendLine($"     margin: {Style.Margins.Top.ToString("0")}pt {Style.Margins.Right.ToString("0")}pt {Style.Margins.Bottom.ToString("0")}pt {Style.Margins.Left.ToString("0")}pt;");
        sb.AppendLine($"     padding: {Style.Paddings.Top.ToString("0")}pt {Style.Paddings.Right.ToString("0")}pt {Style.Paddings.Bottom.ToString("0")}pt {Style.Paddings.Left.ToString("0")}pt;");
        sb.AppendLine($"     border-width: {Style.BorderThickness.Top.ToString("0")}pt {Style.BorderThickness.Right.ToString("0")}pt {Style.BorderThickness.Bottom.ToString("0")}pt {Style.BorderThickness.Left.ToString("0")}pt;");
        sb.AppendLine($"     border-color: {Style.BorderBrush?.Color.ToHtml() ?? "#000000"};");
        sb.AppendLine($"     border-style: solid;");
        sb.AppendLine($"     text-align: {Style.TextAlignment.ToString().ToLowerInvariant()};");

        foreach (var css in AdditionalCss)
        {
            sb.AppendLine($"     {css}");
        }
        
        sb.AppendLine("}");
        renderer.Content.Append(sb);
    }
}