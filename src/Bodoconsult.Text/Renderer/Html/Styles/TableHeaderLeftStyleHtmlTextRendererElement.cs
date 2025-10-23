using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TableHeaderLeftStyle"/> instances
/// </summary>
public class TableHeaderLeftStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderLeftStyle _tableHeaderStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderLeftStyleHtmlTextRendererElement(TableHeaderLeftStyle tableHeaderStyle) : base(tableHeaderStyle)
    {
        _tableHeaderStyle = tableHeaderStyle;
        ClassName = "TableHeaderStyle";
    }
}