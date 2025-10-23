using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TableHeaderRightStyle"/> instances
/// </summary>
public class TableHeaderRightStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderRightStyle _tableHeaderRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderRightStyleHtmlTextRendererElement(TableHeaderRightStyle tableHeaderRightStyle) : base(tableHeaderRightStyle)
    {
        _tableHeaderRightStyle = tableHeaderRightStyle;
        ClassName = "TableHeaderRightStyle";
    }
}