using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Extensions;
using Bodoconsult.Text.Interfaces;
using System.Text;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ListStyle"/> instances
/// </summary>
public class ListStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly ListStyle _listStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ListStyleHtmlTextRendererElement(ListStyle listStyle) : base(listStyle)
    {
        _listStyle = listStyle;
        ClassName = "ListStyle";
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();

        sb.AppendLine($".{Style.GetType().Name}");
        sb.AppendLine("{");
        sb.AppendLine($"     font-family: \"{Style.FontName}\";");
        sb.AppendLine($"     font-size: {Style.FontSize}pt;");
        sb.AppendLine($"     margin: {Style.Margins.Top}pt {Style.Margins.Right}pt {Style.Margins.Bottom}pt {Style.Margins.Left}pt;");
        sb.AppendLine($"     border-width: {Style.BorderThickness.Top}pt {Style.BorderThickness.Right}pt {Style.BorderThickness.Bottom}pt {Style.BorderThickness.Left}pt;");
        sb.AppendLine($"     border-color: {Style.BorderBrush?.Color.ToHtml() ?? "#000000"};");
        sb.AppendLine("}");
        renderer.Content.Append(sb);
    }
}