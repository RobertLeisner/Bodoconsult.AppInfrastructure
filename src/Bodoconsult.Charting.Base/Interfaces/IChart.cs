// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Charting.Base.Interfaces;

/// <summary>
/// Interface for basic chart functionality
/// </summary>
public interface IChart
{

    /// <summary>
    /// Current <see cref="ChartData"/>
    /// </summary>
    IChartData ChartData { get; set; }

    /// <summary>
    /// Creates the chart
    /// </summary>
    void CreateChart();

    /// <summary>
    /// Base formatting for the chart
    /// </summary>
    void Formatting();

    /// <summary>
    /// Render the chart to a PNG image
    /// </summary>
    /// <param name="width">Width in pixels</param>
    /// <param name="height">Height in pixels</param>
    /// <returns>Byte array</returns>
    byte[] RenderImagePng(int width, int height);

    /// <summary>
    /// Initialize the chart
    /// </summary>
    void InitChart();

    /// <summary>
    /// Add a title to the chart
    /// </summary>
    void AddTitle();
}