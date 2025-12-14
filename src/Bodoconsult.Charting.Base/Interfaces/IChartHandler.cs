// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using Bodoconsult.Drawing.SkiaSharp.Interfaces;

namespace Bodoconsult.Charting.Base.Interfaces;

/// <summary>
/// Interface for chart handler instances creating charts from basic input <see cref="ChartData"/>
/// </summary>
public interface IChartHandler
{
    /// <summary>
    /// Current <see cref="ChartData"/> instance to use for chart drawing containing all data to use in the chart
    /// </summary>
    IChartData ChartData { get; }

    /// <summary>
    /// Current <see cref="IBitmapServiceFactory"/> instance to create <see cref="IBitmapService"/> instances
    /// </summary>
    IBitmapServiceFactory BitmapServiceFactory { get; }

    /// <summary>
    /// Export chart as PNG file or JPEG if file extension of target file (ChartData.FileName) is .jpg or .jpeg
    /// </summary>
    void Export();

    /// <summary>
    /// Export chart as PNG file memory stream
    /// </summary>
    MemoryStream ExportMemoryStream();
}