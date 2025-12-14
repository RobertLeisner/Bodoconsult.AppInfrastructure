// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using Bodoconsult.Charting.Base.Interfaces;

namespace Bodoconsult.Charting.Factories;

/// <summary>
/// Public factory for <see cref="ChartHandler"/> instances
/// </summary>
public interface IChartHandlerFactory
{
    /// <summary>
    /// Create an <see cref="IChartHandler"/> instance
    /// </summary>
    /// <param name="chartData">Current <see cref="IChartData"/> instance containing all data to use in the chart</param>
    /// <returns><see cref="IChartHandler"/> instance for creating the chart</returns>
    IChartHandler CreateInstance(IChartData chartData);

}