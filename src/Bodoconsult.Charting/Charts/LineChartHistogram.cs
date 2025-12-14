// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Charting.Extensions;
using ScottPlot;
using System.Globalization;
using Bodoconsult.Charting.Base.Interfaces;

namespace Bodoconsult.Charting;

/// <summary>
/// Create a histogram
/// </summary>
/// <typeparam name="T"></typeparam>

public class LineChartHistogram<T> : BaseChart<T> where T : IChartItemData
{

    //private bool _isContinousXAxis;



    /// <summary>
    /// Creates the chart
    /// </summary>
    public override void CreateChart()
    {

        var style = ChartData.ChartStyle;

        IList<double> xvalues = new List<double>();
        IList<double> values1 = new List<double>();
        //IList<double> values2 = new List<double>();
        //IList<double> values3 = new List<double>();
        //IList<double> values4 = new List<double>();
        //IList<double> values5 = new List<double>();
        //IList<double> values6 = new List<double>();
        //IList<double> values7 = new List<double>();
        //IList<double> values8 = new List<double>();
        //IList<double> values9 = new List<double>();
        //IList<double> values10 = new List<double>();

        var isDate = false;

        foreach (var item in ChartData.DataSource)
        {
            var d = (ChartItemData)item;

            xvalues.Add(d.XValue);
            values1.Add(d.YValue1);
            isDate = d.IsDate;
        }

        var xData = xvalues.ToArray();

        if (values1.Any(x => Math.Abs(x) > 0.0000001))
        {
            PlotBar(xData, values1.ToArray());
        }

        string formatX;
        var formatY = string.IsNullOrEmpty(style.YAxisNumberformat) ? "0" : style.YAxisNumberformat;

        OffsetX = (int)Math.Round(0.012 *ChartData.ChartStyle.Width,0);

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
                Chart.Axes.Left.Label.OffsetX = - OffsetX;

                // use a fixed amount of pixel padding on each side
                PixelPadding padding = new((MaxLength + 3) * OffsetX, OffsetX, 50, 50);
                Chart.Layout.Fixed(padding);
            };
        }

        // Titels for axis

        // X axis
        var label = string.IsNullOrEmpty(ChartData.XLabelText)
            ? ChartData.PropertiesToUseForChart[0]
            : ChartData.XLabelText;

        var labelStyle = Chart.Axes.Bottom.Label;
        labelStyle.Text = label;
        labelStyle.FontName = style.FontName;
        labelStyle.Bold = true;
        labelStyle.FontSize = style.FontSize * style.AxisTitleFontSizeDelta;
        labelStyle.Padding = 5;

        // Y axis
        label = string.IsNullOrEmpty(ChartData.YLabelText)
            ? ChartData.PropertiesToUseForChart[1]
            : ChartData.YLabelText;

        labelStyle = Chart.Axes.Left.Label;
        labelStyle.Text = label;
        labelStyle.FontName = style.FontName;
        labelStyle.Bold = true;
        labelStyle.FontSize = style.FontSize * style.AxisTitleFontSizeDelta;
        labelStyle.Padding = 50;

        base.CreateChart();
    }

    private void PlotBar(double[] xValues, double[] yValues)
    {
        var bars = Chart.Add.Bars(xValues, yValues);

        var pos = (bars.Bars[1].Position - bars.Bars[0].Position) * 0.05;
        foreach (var bar in bars.Bars)
        {
            bar.Size = pos;
        }

        //var pos = 0.0;
        //foreach (var bar in bars.Bars)
        //{
        //    bar.Size = pos + (bar.Position - pos) * 0.5;
        //    pos = bar.Position;
        //}

        //Chart.RenderManager.RenderStarting += (object s, RenderPack rp) =>
        //{
        //    //// this gets called just before each render
        //    //var unitsPerPixel = Chart.Axes.Bottom.Width / rp.DataRect.Width;
        //    //var targetPixelWidth = (float)barWidth;
        //    //var barWidthUnits = targetPixelWidth * unitsPerPixel;

        //    foreach (var bar in bars.Bars)
        //    {
        //        bar.Size = barWidth;
        //    }
        //};
    }

    /// <summary>
    /// Formatting the chart
    /// </summary>
    public override void Formatting()
    {

        base.Formatting();

        var style = ChartData.ChartStyle;

        Chart.Grid.IsVisible = true;

        Chart.Grid.YAxisStyle.MajorLineStyle.IsVisible = false;

        Chart.Grid.YAxisStyle.MajorLineStyle.IsVisible = true;
        Chart.Grid.YAxisStyle.MajorLineStyle.Width = 1;
        Chart.Grid.YAxisStyle.MajorLineStyle.Color = style.GridLineColor.ToScottPlotColor();
        Chart.Grid.YAxisStyle.MajorLineStyle.Pattern = LinePattern.Dashed;

        Chart.Axes.Right.FrameLineStyle.Width = 0;
        Chart.Axes.Top.FrameLineStyle.Width = 0;

        Chart.Axes.Margins(bottom: 0, top: 0, left: 0, right: 0);


        Chart.FigureBackground.Color = Colors.LightBlue;
        Chart.DataBackground.Color = Colors.White;

        //PixelSize size = new(style.Width- 2 * style.ChartBorderCornerRadius, style.Height- 2 * style.ChartBorderCornerRadius);
        //Pixel offset = new(style.ChartBorderCornerRadius,  style.ChartBorderCornerRadius);
        //PixelRect rect = new(size, offset);
        //Chart.Layout.Fixed(rect);


    }
}