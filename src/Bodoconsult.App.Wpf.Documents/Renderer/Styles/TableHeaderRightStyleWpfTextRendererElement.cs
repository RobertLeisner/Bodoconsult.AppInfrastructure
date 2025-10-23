using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TableHeaderRightStyle"/> instances
/// </summary>
public class TableHeaderRightStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderRightStyle _tableHeaderRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderRightStyleWpfTextRendererElement(TableHeaderRightStyle tableHeaderRightStyle) : base(tableHeaderRightStyle)
    {
        _tableHeaderRightStyle = tableHeaderRightStyle;
        ClassName = "TableHeaderRightStyle";
    }
}