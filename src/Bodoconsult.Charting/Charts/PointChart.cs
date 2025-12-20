// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Globalization;
using Bodoconsult.Charting.Base.Interfaces;
using Bodoconsult.Charting.Extensions;
using ScottPlot;

namespace Bodoconsult.Charting;

/// <summary>
/// Creates a point chart
/// </summary>
/// <typeparam name="T">data input type</typeparam>

public class PointChart<T> : BaseChart<T> where T : IChartItemData
{
    /// <summary>
    /// Creates the chart
    /// </summary>
    public override void CreateChart()
    {

        var style = ChartData.ChartStyle;

        var formatX = string.IsNullOrEmpty(style.XAxisNumberformat) ? "0" : style.XAxisNumberformat;
        var formatY = string.IsNullOrEmpty(style.YAxisNumberformat) ? "0" : style.YAxisNumberformat;

        var markerSize = 15;

        var data = new List<PointChartItemData>(ChartData.DataSource.Count);

        for (var index = 0; index < ChartData.DataSource.Count; index++)
        {
            data.Add((PointChartItemData)ChartData.DataSource[index]);
        }

        var maxX = data.Max(x => x.XValue);
        var maxY = data.Max(x => x.YValue);
        var minX = data.Min(x => x.XValue);
        var minY = data.Min(x => x.YValue);

        var deltaX = (maxX - minX) / 35;
        var deltaY = (maxY - minY) / 30;

        if (formatX.Contains("P") || formatX.Contains("%"))
        {
            maxX = Math.Ceiling(maxX / 10) * 10 / 100;
        }
        else
        {
            maxX = Math.Ceiling(maxX / 10) * 10;
        }

        maxY = Math.Ceiling(maxY / 10) * 10;


        if (formatY.Contains("P") || formatY.Contains("%"))
        {
            maxY = Math.Ceiling(maxY / 10) * 10 / 100;
        }
        else
        {
            maxY = Math.Ceiling(maxY / 10) * 10;
        }

        var point = Chart.Add.Scatter(deltaX / 100, deltaY / 100);
        point.Color = Colors.Transparent;
        point.MarkerSize = 1;

        point = Chart.Add.Scatter(maxX * 1.1, maxY * 1.1);
        point.Color = Colors.Transparent;
        point.MarkerSize = 1;

        for (var index = 0; index < data.Count; index++)
        {
            var item = data[index];

            point = Chart.Add.Scatter(item.XValue, item.YValue);
            point.Color = item.Color.ToScottPlotColor();
            point.MarkerSize = markerSize;

            var text = Chart.Add.Text(item.Label, item.XValue + deltaX, item.YValue);
            text.LabelFontColor = item.Color.ToScottPlotColor();
            text.LabelFontName = style.FontName;
            text.LabelFontSize = style.FontSize;
        }

        // X axis
        formatX = string.IsNullOrEmpty(style.XAxisNumberformat) ? "0" : style.XAxisNumberformat;
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
                var label = value.ToString(formatX, CultureInfo.InvariantCulture);
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
                var value = Ticks[i].Position;
                var label = value.ToString(formatY, CultureInfo.InvariantCulture);

                if (label.Length > MaxLength)
                {
                    MaxLength = label.Length;
                }
                Ticks[i] = new Tick(Ticks[i].Position, label);
            }

            //  - 2 * style.ChartBorderCornerRadius
            Chart.Axes.Left.Label.OffsetX = -OffsetX;

            // use a fixed amount of pixel padding on each side
            PixelPadding padding = new(50, 50, 50, 50);
            Chart.Layout.Fixed(padding);
        };

        base.CreateChart();
    }


    ///// <summary>
    ///// Formatting the chart
    ///// </summary>
    //public override void Formatting()
    //{
    //    base.Formatting();


    //    //var style = ChartData.ChartStyle;

    //    //Chart.Grid(enable: true, lineStyle: LineStyle.Dash, color: style.GridLineColor);

    //    ////Chart.Legend(enableLegend: true, location: legendLocation.lowerRight, backColor: Color.WhiteSmoke, frameColor: Color.Transparent,
    //    ////    fontSize: style.FontSize * style.LegendFontSizeDelta, bold: false, fontColor: style.FontColor);
    //}
}