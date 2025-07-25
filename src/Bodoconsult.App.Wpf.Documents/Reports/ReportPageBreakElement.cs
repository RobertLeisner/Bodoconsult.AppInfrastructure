using Bodoconsult.App.Wpf.Documents.Services;
using PropertyChanged;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Add a page break to a WPF report
/// </summary>
[AddINotifyPropertyChangedInterface]
public class ReportPageBreakElement : IReportElement
{
    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="service"></param>
    public void RenderIt(FlowDocumentService service)
    {
        service.AddPageBreak();
    }
}