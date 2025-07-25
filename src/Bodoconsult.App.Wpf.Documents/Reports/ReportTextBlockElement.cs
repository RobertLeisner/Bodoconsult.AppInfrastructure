using Bodoconsult.App.Wpf.Documents.General;
using Bodoconsult.App.Wpf.Documents.Services;
using PropertyChanged;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Add a textblock containing one or more tags of type &gt;P&lt;/&gt;/P&lt; or &gt;img src="???" title="???"&lt;
/// </summary>
[AddINotifyPropertyChangedInterface]
public class ReportTextBlockElement : IReportElement
{
    /// <summary>
    /// default constructor
    /// </summary>
    public ReportTextBlockElement()
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
                    service.AddTextBlock(Content, "ExtraSmallText");
                    break;
                case FontSize.Small:
                    service.AddTextBlock(Content, "SmallText");
                    break;
                case FontSize.Regular:
                    service.AddTextBlock(Content, "Standard");
                    break;
                default:
                    service.AddTextBlock(Content, "Standard");
                    break;
            }
        }
        else
        {
            service.AddTextBlock(Content, StyleName);
        }

    }
}