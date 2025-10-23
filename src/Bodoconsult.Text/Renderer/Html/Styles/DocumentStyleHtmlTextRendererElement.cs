using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using System.Text;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="DocumentStyle"/> instances
/// </summary>
public class DocumentStyleHtmlTextRendererElement : HtmlPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _documentStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DocumentStyleHtmlTextRendererElement(DocumentStyle documentStyle) : base(documentStyle)
    {
        _documentStyle = documentStyle;
        ClassName = "DocumentStyle";
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        var sb = new StringBuilder();

        sb.AppendLine("@page");
        sb.AppendLine("{");
        sb.AppendLine($"     size: {Style.PaperFormatName} {(Style.PageWidth > Style.PageHeight ? " landscape" : "")};");
        sb.AppendLine($"     margin: {Style.MarginTop}cm {Style.MarginRight}cm {Style.MarginBottom}cm {Style.MarginLeft}cm;");
        sb.AppendLine("}");

        sb.AppendLine("body");
        sb.AppendLine("{");
        sb.AppendLine($"     width: 650px;");
        sb.AppendLine("}");
        renderer.Content.Append(sb);
    }
}