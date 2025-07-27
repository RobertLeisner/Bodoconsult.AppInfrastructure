// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Services;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Interface for WPF report elements, which must have a RenderIt() method at least
/// </summary>
public interface IReportElement
{
    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="service"></param>
    void RenderIt(FlowDocumentService service);
}