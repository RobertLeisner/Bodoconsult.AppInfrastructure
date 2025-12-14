// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Globalization;
using Bodoconsult.Charting.Base.Interfaces;
using Bodoconsult.Charting.Extensions;
using ScottPlot;

namespace Bodoconsult.Charting;

/// <summary>
/// Creates a line chart
/// </summary>
/// <typeparam name="T">input data type</typeparam>

public class LineChart<T> : BaseChart<T> where T : IChartItemData
{

    //private bool _isContinousXAxis;

    /// <summary>
    /// Creates the chart
    /// </summary>
    public override void CreateChart()
    {

        var style = ChartData.ChartStyle;
        var count = ChartData.DataSource.Count;

        var xvalues = new List<double>(count);
        var values1 = new List<double>(count);
        var values2 = new List<double>(count);
        var values3 = new List<double>(count);
        var values4 = new List<double>(count);
        var values5 = new List<double>(count);
        var values6 = new List<double>(count);
        var values7 = new List<double>(count);
        var values8 = new List<double>(count);
        var values9 = new List<double>(count);
        var values10 = new List<double>(count);
        var labels = new List<string>();
        var indexers = new List<double>();


        var isDate = false;

        var modulo = count / 10;

        for (var index = 0; index < count; index++)
        {
            var d = (ChartItemData)ChartData.DataSource[index];

            xvalues.Add(d.XValue);
            values1.Add(d.YValue1);
            values2.Add(d.YValue2);
            values3.Add(d.YValue3);
            values4.Add(d.YValue4);
            values5.Add(d.YValue5);
            values6.Add(d.YValue6);
            values7.Add(d.YValue7);
            values8.Add(d.YValue8);
            values9.Add(d.YValue9);
            values10.Add(d.YValue10);
            isDate = d.IsDate;

            if (string.IsNullOrEmpty(d.Label))
            {
                continue;
            }

            if (index % modulo != 0)
            {
                continue;
            }

            labels.Add(d.Label);
            indexers.Add(d.XValue);
            //else
            //{
            //    labels.Add(null);
            //}
        }

        var xData = xvalues.ToArray();

        if (values1.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values1.ToArray(), markerShape: MarkerShape.None, lineWidth: 2D, label: GetLabelForSeries(0));
        if (values2.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values2.ToArray(), markerShape: MarkerShape.None, lineWidth: 2D, label: GetLabelForSeries(1));
        if (values3.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values3.ToArray(), markerShape: MarkerShape.None, lineWidth: 2D, label: GetLabelForSeries(2));
        if (values4.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values4.ToArray(), markerShape: MarkerShape.None, lineWidth: 2D, label: GetLabelForSeries(3));
        if (values5.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values5.ToArray(), markerShape: MarkerShape.None, lineWidth: 2D, label: GetLabelForSeries(4));
        if (values6.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values6.ToArray(), markerShape: MarkerShape.None, lineWidth: 2D, label: GetLabelForSeries(5));
        if (values7.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values7.ToArray(), markerShape: MarkerShape.None, lineWidth: 2D, label: GetLabelForSeries(6));
        if (values8.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values8.ToArray(), markerShape: MarkerShape.None, lineWidth: 2D, label: GetLabelForSeries(7));
        if (values9.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values9.ToArray(), markerShape: MarkerShape.None, lineWidth: 2D, label: GetLabelForSeries(8));
        if (values10.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values10.ToArray(), markerShape: MarkerShape.None, lineWidth: 2D, label: GetLabelForSeries(9));

        string formatX;
        var formatY = string.IsNullOrEmpty(style.YAxisNumberformat) ? "0" : style.YAxisNumberformat;
        

        OffsetX = (int)Math.Round(0.012 * ChartData.ChartStyle.Width, 0);

        // Formatting axis ticks
        if (isDate)
        {
            formatX = string.IsNullOrEmpty(style.XAxisNumberformat) ? CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern : style.XAxisNumberformat;

            Chart.Axes.DateTimeTicksBottom();

            Chart.RenderManager.RenderStarting += (_, _) =>
            {
                // X axis
                TickGen = Chart.Axes.Bottom.TickGenerator;
                TickGen.MaxTickCount = 10;
                Ticks = TickGen.Ticks;
                for (var i = 0; i < Ticks.Length; i++)
                {
                    if (!Ticks[i].IsMajor)
                    {
                        continue;
                    }
                    var dt = DateTime.FromOADate(Ticks[i].Position);
                    var label = dt.ToString(formatX, CultureInfo.InvariantCulture);
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
                PixelPadding padding = new((MaxLength + 3) * OffsetX, OffsetX, 50, 50);
                Chart.Layout.Fixed(padding);
            };
        }
        else
        {
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
                PixelPadding padding = new((MaxLength + 3) * OffsetX, OffsetX, 50, 50);
                Chart.Layout.Fixed(padding);
            };
        }

        if (labels.Any())
        {
            Chart.Axes.Bottom.SetTicks(indexers.ToArray(), labels.ToArray());
        }


        base.CreateChart();
    }

    private void PlotScatter(double[] xValues, double[] yValues, MarkerShape markerShape, double lineWidth, string label)
    {
        var sp = Chart.Add.Scatter(xValues, yValues);
        sp.MarkerShape = markerShape;
        //sp.LineWidth = lineWidth;
        sp.LegendText = label;
        sp.LineWidth = (float)lineWidth;
    }


    /// <summary>
    /// Formatting the chart
    /// </summary>
    public override void Formatting()
    {
        base.Formatting();

        var style = ChartData.ChartStyle;

        ////Chart.Legend(enableLegend: true, location: legendLocation.upperCenter, backColor: Color.WhiteSmoke, frameColor: Color.Transparent,
        ////    fontSize: style.FontSize * style.LegendFontSizeDelta, bold: false, fontColor: style.FontColor);

        //var legend = Chart.Legend();
        //legend.IsVisible = true;
        //legend.Location = Alignment.UpperCenter;
        //legend.FillColor = Color.WhiteSmoke;
        //legend.OutlineColor = Color.Transparent;
        //legend.FontSize = style.FontSize * style.LegendFontSizeDelta;
        //legend.FontColor = style.FontColor;
        //legend.FontBold = false;


        //Chart.Grid(enable: true, lineStyle: LineStyle.Dash, color: style.GridLineColor);
        Chart.Grid.IsVisible = true;

        Chart.Grid.YAxisStyle.MajorLineStyle.IsVisible = false;

        Chart.Grid.YAxisStyle.MajorLineStyle.IsVisible = true;
        Chart.Grid.YAxisStyle.MajorLineStyle.Width = 1;
        Chart.Grid.YAxisStyle.MajorLineStyle.Color = style.GridLineColor.ToScottPlotColor();
        Chart.Grid.YAxisStyle.MajorLineStyle.Pattern = LinePattern.Dashed;



        
    }

}