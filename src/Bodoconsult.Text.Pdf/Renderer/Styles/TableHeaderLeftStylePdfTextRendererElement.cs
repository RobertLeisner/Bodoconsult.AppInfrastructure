using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TableHeaderLeftStyle"/> instances
/// </summary>
public class TableHeaderLeftStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderLeftStyle _tableHeaderStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderLeftStylePdfTextRendererElement(TableHeaderLeftStyle tableHeaderStyle) : base(tableHeaderStyle)
    {
        _tableHeaderStyle = tableHeaderStyle;
        ClassName = "TableHeaderStyle";
    }
}