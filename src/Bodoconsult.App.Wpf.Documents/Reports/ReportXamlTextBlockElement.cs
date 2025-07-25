using System.Windows.Documents;
using Bodoconsult.App.Wpf.Documents.General;
using Bodoconsult.App.Wpf.Documents.Services;
using PropertyChanged;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Add a XAML textblock to the report. Maybe a full <see cref="FlowDocument"/> or the valid blocks of such a document
/// </summary>
[AddINotifyPropertyChangedInterface]
public class ReportXamlTextBlockElement : IReportElement
{
    /// <summary>
    /// default constructor
    /// </summary>
    public ReportXamlTextBlockElement()
    {
        FontSize = FontSize.Regular;
    }

    /// <summary>
    /// Content of the paragraph
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Logical font size of the report paragraph
    /// </summary>
    public FontSize FontSize { get; set; }


    /// <summary>
    /// Style name to use for the text block
    /// </summary>
    public string StyleName { get; set; }

    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="service"></param>
    public void RenderIt(FlowDocumentService service)
    {
        if (string.IsNullOrEmpty(StyleName))
        {
            switch (FontSize)
            {
                case FontSize.ExtraSmall:
                    service.AddXamlTextblock(Content, "ExtraSmallText");
                    break;
                case FontSize.Small:
                    service.AddXamlTextblock(Content, "SmallText");
                    break;
                case FontSize.Regular:
                    service.AddXamlTextblock(Content);
                    break;
                default:
                    service.AddXamlTextblock(Content);
                    break;
            }
        }
        else
        {
            service.AddXamlTextblock(Content, StyleName);
        }

    }
}