// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Services;
using PropertyChanged;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Sub-headline element for a report
/// </summary>
[AddINotifyPropertyChangedInterface]
public class ReportSubheaderElement : IReportElement
{

    /// <summary>
    /// Content of the subheader paragraph
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="service"></param>
    public void RenderIt(FlowDocumentService service)
    {
        service.AddSubheader(Content);
    }
}