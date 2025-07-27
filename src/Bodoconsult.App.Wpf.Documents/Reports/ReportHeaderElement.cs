// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Services;
using PropertyChanged;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Header element for WPF report
/// </summary>
[AddINotifyPropertyChangedInterface]
public class ReportHeaderElement : IReportElement
{
    /// <summary>
    /// default header
    /// </summary>
    public ReportHeaderElement()
    {
        Level = 1;
    }

    /// <summary>
    /// Content of the paragraph
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Logical level of the header (1=top to 5=lowest, otherwise only a plain paragrapgh is added. 1 is default)
    /// </summary>
    public int Level { get; set; }


    /// <summary>
    /// If NoCount is true, the header will not be included in the header counting
    /// </summary>
    public bool NoCount { get; set; }



    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="service"></param>
    public void RenderIt(FlowDocumentService service)
    {
        switch (Level)
        {
            case 1:
                service.AddHeader1(Content, NoCount);
                break;
            case 2:
                service.AddHeader2(Content, NoCount);
                break;
            case 3:
                service.AddHeader3(Content, NoCount);
                break;
            case 4:
                service.AddHeader4(Content);
                break;
            case 5:
                service.AddHeader5(Content);
                break;
            default:
                service.AddParagraph(Content);
                break;
        }
    }
}