// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Services;
using PropertyChanged;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Title2 element for a report
/// </summary>
[AddINotifyPropertyChangedInterface]
public class ReportTitle2Element : IReportElement
{

    /// <summary>
    /// Content of the title paragraph
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="service"></param>
    public void RenderIt(FlowDocumentService service)
    {
        service.AddTitle2(Content);
    }
}