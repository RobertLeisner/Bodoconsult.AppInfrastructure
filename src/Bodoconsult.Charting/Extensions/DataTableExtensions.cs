// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using Bodoconsult.Charting.Base.Interfaces;
using System.Data;
using Bodoconsult.Charting.Util;

namespace Bodoconsult.Charting.Extensions;

/// <summary>
/// Extension methods for <see cref="DataTable"/>
/// </summary>
public static class DataTableExtensions
{


    /// <summary>
    /// Convert a <see cref="DataTable"/> to a list of <see cref="PieChartItemData"/> object
    /// </summary>
    /// <param name="dataTable">Current data table</param>
    /// <param name="columns">String with selected columns separated with comma or null (if all columns should be used). Column count is 0-based.</param>
    /// <param name="chartData">Current chart data</param>
    public static void ToPieChartItemData(this DataTable dataTable, string columns, ChartData chartData)
    {
        ChartUtility.DataTableToPieChartItemData(dataTable, columns, chartData);
    }

    /// <summary>
    /// Convert a <see cref="DataTable"/> to a list of <see cref="ChartItemData"/> object
    /// </summary>
    /// <param name="dataTable">Current data table</param>
    /// <param name="columns">String with selected columns separated with comma or null (if all columns should be used). Column count is 0-based.</param>
    /// <param name="chartData">Current chart data</param>
    public static void ToChartItemData(this DataTable dataTable, string columns, ChartData chartData)
    {
        ChartUtility.DataTableToChartItemData(dataTable, columns, chartData);
    }

    /// <summary>
    /// Convert a <see cref="DataTable"/> to a list of <see cref="PointChartItemData"/> object
    /// </summary>
    /// <param name="dataTable">Current data table</param>
    /// <param name="columns">String with selected columns separated with comma or null (if all columns should be used). Column count is 0-based.</param>
    /// <param name="chartData">Current chart data</param>
    public static void ToPointChartItemData(this DataTable dataTable, string columns, ChartData chartData)
    {
        ChartUtility.DataTableToPointChartItemData(dataTable, columns, chartData);
    }

}