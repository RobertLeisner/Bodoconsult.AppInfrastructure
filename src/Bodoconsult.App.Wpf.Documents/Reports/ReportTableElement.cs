using Bodoconsult.App.Wpf.Documents.General;
using Bodoconsult.App.Wpf.Documents.Services;
using PropertyChanged;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Table element of a WPF report
/// </summary>
[AddINotifyPropertyChangedInterface]
public class ReportTableElement : IReportElement
{
    /// <summary>
    /// default constructor
    /// </summary>
    public ReportTableElement()
    {
        TableType = TableTypes.Normal;
        KeepTogether = true;
    }
    /// <summary>
    /// Data to print in the table
    /// </summary>
    public string[,] Data { get; set; }

    /// <summary>
    /// Type of the table. See values for <see cref="TableTypes"/>
    /// </summary>
    public TableTypes TableType { get; set; }


    /// <summary>
    /// Keep the table together ron one page (use false if table gets longer then one page). Default: true
    /// </summary>
    public bool KeepTogether { get; set; }

    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="service"></param>
    public void RenderIt(FlowDocumentService service)
    {
        service.AddTable(Data, TableType);
    }
}