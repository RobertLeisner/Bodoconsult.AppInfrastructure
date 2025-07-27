// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows;
using Bodoconsult.App.Wpf.Documents.General;
using Bodoconsult.App.Wpf.Documents.Services;
using PropertyChanged;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Add a paragraph to a report
/// </summary>
[AddINotifyPropertyChangedInterface]
public class ReportParagraphElement : IReportElement
{

    /// <summary>
    /// default constructor
    /// </summary>
    public ReportParagraphElement()
    {
        FontSize = FontSize.Regular;
        TextAlignment = TextAlignment.Left;
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
    /// Alignment of text in the paragraph
    /// </summary>
    public TextAlignment TextAlignment { get; set; }


    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="service"></param>
    public void RenderIt(FlowDocumentService service)
    {

        switch (TextAlignment)
        {
            case TextAlignment.Right:
                switch (FontSize)
                {
                    case FontSize.ExtraSmall:
                        service.AddExtraSmallParagraphRight(Content);
                        break;
                    case FontSize.Small:
                        service.AddSmallParagraphRight(Content);
                        break;
                    case FontSize.Regular:
                        service.AddParagraphRight(Content);
                        break;
                    default:
                        service.AddParagraphRight(Content);
                        break;
                }
                break;

            case TextAlignment.Center:
                switch (FontSize)
                {
                    case FontSize.ExtraSmall:
                        service.AddExtraSmallParagraphCentered(Content);
                        break;
                    case FontSize.Small:
                        service.AddSmallParagraphCentered(Content);
                        break;
                    case FontSize.Regular:
                        service.AddParagraphCentered(Content);
                        break;
                    default:
                        service.AddParagraphCentered(Content);
                        break;
                }
                break;
            default:
                switch (FontSize)
                {
                    case FontSize.ExtraSmall:
                        service.AddExtraSmallParagraph(Content);
                        break;
                    case FontSize.Small:
                        service.AddSmallParagraph(Content);
                        break;
                    case FontSize.Regular:
                        service.AddParagraph(Content);
                        break;
                    default:
                        service.AddParagraph(Content);
                        break;
                }
                break;
        }


    }
}