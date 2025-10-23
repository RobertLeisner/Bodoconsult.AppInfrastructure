using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TableHeaderRightStyle"/> instances
/// </summary>
public class TableHeaderRightStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderRightStyle _tableHeaderRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderRightStylePdfTextRendererElement(TableHeaderRightStyle tableHeaderRightStyle) : base(tableHeaderRightStyle)
    {
        _tableHeaderRightStyle = tableHeaderRightStyle;
        ClassName = "TableHeaderRightStyle";
    }
}