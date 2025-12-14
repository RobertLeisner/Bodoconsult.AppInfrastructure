// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Charting.Base.Interfaces;

/// <summary>
/// Point item to show in a point chart
/// </summary>
public class PointChartItemData: IChartItemData
{
    /// <summary>
    /// X axis value
    /// </summary>
    public double XValue { get; set; }

    /// <summary>
    /// Y axis value
    /// </summary>
    public double YValue { get; set; }

    /// <summary>
    /// Label for the data point
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// Color index for the data point
    /// </summary>
    public TypoColor Color { get; set; }
}