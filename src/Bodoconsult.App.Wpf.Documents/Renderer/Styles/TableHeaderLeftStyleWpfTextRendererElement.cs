using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TableHeaderLeftStyle"/> instances
/// </summary>
public class TableHeaderLeftStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderLeftStyle _tableHeaderStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderLeftStyleWpfTextRendererElement(TableHeaderLeftStyle tableHeaderStyle) : base(tableHeaderStyle)
    {
        _tableHeaderStyle = tableHeaderStyle;
        ClassName = "TableHeaderStyle";
    }
}