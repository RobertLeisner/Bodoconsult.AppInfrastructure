using System.Windows;
using Bodoconsult.App.Wpf.Documents.Services;
using PropertyChanged;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Numbered list element for WPF report
/// </summary>
[AddINotifyPropertyChangedInterface]
public class ReportNumberedListElement : IReportElement
{
    ///// <summary>
    ///// default header
    ///// </summary>
    //public ReportNumberedListElement()
    //{

    //}


    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<string> Data;

    /// <summary>
    /// 
    /// </summary>
    public TextMarkerStyle ListStyle;


  
    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="service"></param>
    public void RenderIt(FlowDocumentService service)
    {
        service.AddNumberedList(Data, ListStyle);
    }
}