// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.Charting.Base.Interfaces;

/// <summary>
/// Item data for a pie chart
/// </summary>
public class PieChartItemData: IChartItemData
{
    /// <summary>
    /// X axis value
    /// </summary>
    public string XValue { get; set; }
    
    /// <summary>
    /// Value for the series
    /// </summary>
    public double YValue { get; set; }
}