// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.Charting.Base.Interfaces;

/// <summary>
/// Available chart types
/// </summary>
public enum ChartType
{
#pragma warning disable 1591
    BarChart,
    ColumnChart,
    LineChart,
    PieChart,
    PointChart,
    StackedBarChart,
    StackedColumn100Chart,
    StackedColumnChart,
    StockChart,
    Histogram
#pragma warning restore 1591
}