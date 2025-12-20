// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Globalization;
using Bodoconsult.Charting.Base.Interfaces;
using Bodoconsult.Charting.Extensions;
using ScottPlot;

namespace Bodoconsult.Charting;

/// <summary>
/// Create a bar chart
/// </summary>
/// <typeparam name="T">input data type</typeparam>

public class BarChart<T> : BaseChart<T> where T : IChartItemData
{

    private string[] _labels;

    /// <summary>
    /// Creates the chart
    /// </summary>
    public override void CreateChart()
    {

        //var style = ChartData.ChartStyle;

        _labels = new string[ChartData.DataSource.Count];
        var indexers = new double[ChartData.DataSource.Count];
        var values1 = new double[ChartData.DataSource.Count];
        var values2 = new double[ChartData.DataSource.Count];
        var values3 = new double[ChartData.DataSource.Count];
        var values4 = new double[ChartData.DataSource.Count];
        var values5 = new double[ChartData.DataSource.Count];
        var values6 = new double[ChartData.DataSource.Count];
        var values7 = new double[ChartData.DataSource.Count];
        var values8 = new double[ChartData.DataSource.Count];
        var values9 = new double[ChartData.DataSource.Count];
        var values10 = new double[ChartData.DataSource.Count];

        for (var index = 0; index < ChartData.DataSource.Count; index++)
        {
            var item = (ChartItemData)ChartData.DataSource[index];

            if (!string.IsNullOrEmpty(item.Label))
            {
                _labels[index] = item.Label;
                item.XValue = index;
            }
            else
            {
                _labels[index] = item.XValue.ToString(CultureInfo.CurrentCulture);
            }

            indexers[index] = index;
            values1[index] = item.YValue1;
            values2[index] = item.YValue2;
            values3[index] = item.YValue3;
            values4[index] = item.YValue4;
            values5[index] = item.YValue5;
            values6[index] = item.YValue6;
            values7[index] = item.YValue7;
            values8[index] = item.YValue8;
            values9[index] = item.YValue9;
            values10[index] = item.YValue10;
        }

        if (values1.Any(x => Math.Abs(x) > 0.0000001)) PlotBar(indexers, values1);
        if (values2.Any(x => Math.Abs(x) > 0.0000001)) PlotBar(indexers, values2);
        if (values3.Any(x => Math.Abs(x) > 0.0000001)) PlotBar(indexers, values3);
        if (values4.Any(x => Math.Abs(x) > 0.0000001)) PlotBar(indexers, values4);
        if (values5.Any(x => Math.Abs(x) > 0.0000001)) PlotBar(indexers, values5);
        if (values6.Any(x => Math.Abs(x) > 0.0000001)) PlotBar(indexers, values6);
        if (values7.Any(x => Math.Abs(x) > 0.0000001)) PlotBar(indexers, values7);
        if (values8.Any(x => Math.Abs(x) > 0.0000001)) PlotBar(indexers, values8);
        if (values9.Any(x => Math.Abs(x) > 0.0000001)) PlotBar(indexers, values9);
        if (values10.Any(x => Math.Abs(x) > 0.0000001)) PlotBar(indexers, values10);
        
        base.CreateChart();

    }

    private void PlotBar(double[] xValues, double[] yValues)
    {


        var bars = Chart.Add.Bars(xValues, yValues);
        bars.ValueLabelStyle.Bold = true;
        bars.ValueLabelStyle.FontSize = ChartData.ChartStyle.FontSize;

        var i = 0;
        
        foreach (var bar in bars.Bars)
        {
            bar.Orientation = Orientation.Horizontal;
            bar.LabelOnTop = false;
            bar.CenterLabel = true;
            bar.FillColor = GetColor(i);
            bar.Label = _labels[i];

            i++;
        }
    }

    /// <summary>
    /// Formatting the chart
    /// </summary>
    public override void Formatting()
    {

        base.Formatting();

        var style = ChartData.ChartStyle;

        //Chart.Grid(enable: true, lineStyle: LineStyle.Dash, color: style.GridLineColor);
        Chart.Grid.XAxisStyle.MajorLineStyle.Width = 0;

        Chart.Grid.YAxisStyle.MajorLineStyle.Width = 1;
        Chart.Grid.YAxisStyle.MajorLineStyle.Color = style.GridLineColor.ToScottPlotColor();
        Chart.Grid.YAxisStyle.MajorLineStyle.Pattern = LinePattern.Dashed;

        // Titels for axis

        // X axis: write y value as x title
        var label = string.IsNullOrEmpty(ChartData.YLabelText)
            ? ChartData.PropertiesToUseForChart[1]
            : ChartData.YLabelText;

        var labelStyle = Chart.Axes.Bottom.Label;
        labelStyle.Text = label;
        labelStyle.FontName = style.FontName;
        labelStyle.Bold = true;
        labelStyle.FontSize = style.FontSize * style.AxisTitleFontSizeDelta;

        // Y axis: write x value as x title
        label = string.IsNullOrEmpty(ChartData.XLabelText)
            ? ChartData.PropertiesToUseForChart[0]
            : ChartData.XLabelText;

        labelStyle = Chart.Axes.Left.Label;
        labelStyle.Text = label;

        // X axis
        var formatX = string.IsNullOrEmpty(style.XAxisNumberformat) ? "0" : style.XAxisNumberformat;
        Chart.RenderManager.RenderStarting += (_, _) =>
        {
            TickGen = Chart.Axes.Bottom.TickGenerator;
            TickGen.MaxTickCount = 10;
            Ticks = TickGen.Ticks;
            for (var i = 0; i < Ticks.Length; i++)
            {
                if (!Ticks[i].IsMajor)
                {
                    continue;
                }
                var value = Ticks[i].Position;
                label = value.ToString(formatX, CultureInfo.InvariantCulture);
                Ticks[i] = new Tick(Ticks[i].Position, label);
            }

            // Y axis
            TickGen = Chart.Axes.Left.TickGenerator;
            TickGen.MaxTickCount = 10;
            Ticks = TickGen.Ticks;
            for (var i = 0; i < Ticks.Length; i++)
            {
                if (!Ticks[i].IsMajor)
                {
                    continue;
                }

                label = Ticks[i].Label;

                if (label.Length > MaxLength)
                {
                    MaxLength = label.Length;
                }
            }

            Chart.Axes.Left.TickLabelStyle.IsVisible = false;
            Chart.Axes.Left.MajorTickStyle.Length = 0;
            Chart.Axes.Left.MinorTickStyle.Length = 0;
        };
    }
}