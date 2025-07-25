// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.IO;
using Bodoconsult.App.Wpf.Documents.Services;
using PropertyChanged;

namespace Bodoconsult.App.Wpf.Documents.Reports;

/// <summary>
/// Add an image to a WPF report. Image Data provided as stream with <see cref="ImageData"/> 
/// or as file system path with <see cref="ImagePath"/>
/// </summary>
[AddINotifyPropertyChangedInterface]
public class ReportImageElement : IReportElement
{
    /// <summary>
    /// Path to the image to render in the report. Used alternatively to <see cref="ImageData"/>
    /// </summary>
    public string ImagePath { get; set; }


    /// <summary>
    /// Image Data as stream. Used alternatively to <see cref="ImagePath"/>
    /// </summary>
    public MemoryStream ImageData { get; set; }

    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="service"></param>
    public void RenderIt(FlowDocumentService service)
    {
        if (string.IsNullOrEmpty(ImagePath))
        {
            if (Width > 0 || Height>0)
            {
                service.AddImage(ImageData, Width, Height);
            }
            else
            {
                service.AddImage(ImageData);
            }
        }
        else
        {
            if (Width > 0 || Height > 0)
            {
                service.AddImage(ImagePath, Width, Height);
            }
            else
            {
                service.AddImage(ImagePath);
            }
        }
            
    }

    /// <summary>
    /// Width of the figure's image. Default: 0 means use allowed MaxWidth for the document. 
    /// MaxWidth can be set with <see cref="TypographySettingsService.MaxImageWidth"/>
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Height of the figure's image. Default: 0 means use allowed MaxHeight for the document
    /// MaxHeight can be set with <see cref="TypographySettingsService.MaxImageHeight"/>
    /// </summary>
    public int Height { get; set; }

}