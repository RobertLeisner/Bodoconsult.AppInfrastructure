// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.Abstractions.Typography;

/// <summary>
/// Base class for typography data
/// </summary>
public class TypographyBase : ITypography
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TypographyBase()
    {
        // Default page DIN A4 
        PaperFormatName = "A4";
        PageHeight = 29.4;
        PageWidth = 21.0;

        FontName = "Calibri";
        FontSize = 11;
        SmallFontSize = FontSize - 2;
        ExtraSmallFontSize = SmallFontSize - 2;

        HeadingFontName = FontName;
        HeadingFontSize5 = FontSize;
        HeadingFontSize4 = HeadingFontSize5 + 2;
        HeadingFontSize3 = HeadingFontSize4 + 2;
        HeadingFontSize2 = HeadingFontSize3 + 2;
        HeadingFontSize1 = HeadingFontSize2 + 4;

        TitleFontName = FontName;
        SubTitleFontName = FontName;

        TitleFontSize = HeadingFontSize1 + 6;
        SubTitleFontSize = HeadingFontSize1 + 2;

        LineHeight = 0.5;
        ColumnDividerWidth = 0.5;
        ColumnWidth = 2.5;
        ColumnCount = 6;
        DotsPerInch = 96;
        LogoWidth = 2 * ColumnWidth + ColumnDividerWidth;

        MarginLeftFactor = 2;
        MarginRightFactor = 2;
        MarginTopFactor = 1;
        MarginBottomFactor = 2;

        SetMargins();

        ChartStyle = new ChartStyle();
        Copyright = "Bodoconsult GmbH";

        TableBodyBackground = TypoColors.White;
        TableHeaderBackground = TypoColors.White;
        TableBodyUnborderedBackground = TypoColors.Transparent;
        TableHeaderUnborderedBackground = TypoColors.Transparent;
        TableCornerRadius = 0.3;
        TableBorderWidth = 0.05;
        TableBorderColor = TypoColor.FromArgb(178, 204, 255);
    }

    /// <summary>
    /// Border color of the table
    /// </summary>
    public TypoColor TableBorderColor { get; set; }

    /// <summary>
    /// Border width of a table in cm
    /// </summary>
    public double TableBorderWidth { get; set; }

    /// <summary>
    /// Copyright to print in charts and other items
    /// </summary>
    public string Copyright { get; set; }

    /// <summary>
    /// Name of the paper format, i.e. A4, Letter, Legal
    /// </summary>
    public string PaperFormatName { get; set; }

    /// <summary>
    /// Page width in cm
    /// </summary>
    public double PageWidth { get; set; }

    /// <summary>
    /// Page height in cm
    /// </summary>
    public double PageHeight { get; set; }

    /// <summary>
    /// Default font name
    /// </summary>
    public string FontName { get; set; }

    /// <summary>
    /// Default font size in pt
    /// </summary>
    public double FontSize { get; set; }

    /// <summary>
    /// Small font size in pt
    /// </summary>
    public double SmallFontSize { get; set; }

    /// <summary>
    /// Tiny font size in pt
    /// </summary>
    public double ExtraSmallFontSize { get; set; }

    /// <summary>
    /// Title font name
    /// </summary>
    public string TitleFontName { get; set; }

    /// <summary>
    /// Title font size in pt
    /// </summary>
    public double TitleFontSize { get; set; }


    /// <summary>
    /// Subtitle font name
    /// </summary>
    public string SubTitleFontName { get; set; }

    /// <summary>
    /// Subtitle font size in pt
    /// </summary>
    public double SubTitleFontSize { get; set; }

    /// <summary>
    /// Font name used for headings
    /// </summary>
    public string HeadingFontName { get; set; }

    /// <summary>
    /// Font size used for headings of level 1 in pt
    /// </summary>
    public double HeadingFontSize1 { get; set; }

    /// <summary>
    /// Font size used for headings of level 2 in pt
    /// </summary>
    public double HeadingFontSize2 { get; set; }

    /// <summary>
    /// Font size used for headings of level 3 in pt
    /// </summary>
    public double HeadingFontSize3 { get; set; }

    /// <summary>
    /// Font size used for headings of level 4 in pt
    /// </summary>
    public double HeadingFontSize4 { get; set; }

    /// <summary>
    /// Font size used for headings of level 5 in pt
    /// </summary>
    public double HeadingFontSize5 { get; set; }

    /// <summary>
    /// Line height in cm (Zeilenabstand ZAB in cm)
    /// </summary>
    public double LineHeight { get; set; }

    /// <summary>
    /// Width of the column divider in cm (Spaltenabstand in cm)
    /// </summary>
    public double ColumnDividerWidth { get; set; }

    /// <summary>
    /// Column width in cm
    /// </summary>
    public double ColumnWidth { get; set; }

    /// <summary>
    /// Sets the factor for the calculation of the left margin. See <see cref="ITypography.SetMargins"/> for details
    /// </summary>
    public double MarginLeftFactor { get; set; }

    /// <summary>
    /// Sets the factor for the calculation of the right margin. See <see cref="ITypography.SetMargins"/> for details
    /// </summary>
    public double MarginRightFactor { get; set; }

    /// <summary>
    /// Sets the factor for the calculation of the top margin. See <see cref="ITypography.SetMargins"/> for details
    /// </summary>
    public double MarginTopFactor { get; set; }

    /// <summary>
    /// Sets the factor for the calculation of the bottom margin. See <see cref="ITypography.SetMargins"/> for details
    /// </summary>
    public double MarginBottomFactor { get; set; }

    /// <summary>
    /// Number of columns to use for the layout in the type area
    /// </summary>
    public int ColumnCount { get; set; }


    /// <summary>
    /// Unit used for margins in cm (Teil in cm)
    /// 
    /// <see cref="MarginUnit"/> = <see cref="PageWidth"/> - <see cref="TypeAreaWidth"/> / (<see cref="SetMargins"/>.left + <see cref="SetMargins"/>.right)
    /// </summary>
    public double MarginUnit { get; private set; }

    /// <summary>
    /// Left margin in cm
    /// </summary>
    public double MarginLeft { get; private set; }

    /// <summary>
    /// Right margin in cm
    /// </summary>
    public double MarginRight { get; private set; }

    /// <summary>
    /// Top margin in cm
    /// </summary>
    public double MarginTop { get; private set; }

    /// <summary>
    /// Bottom margin in cm
    /// </summary>
    public double MarginBottom { get; private set; }

    /// <summary>
    /// Height of the page header in cm
    /// </summary>
    public double PageHeaderHeight { get; set; }

    /// <summary>
    /// Margin between page header and type area in cm
    /// </summary>
    public double PageHeaderMargin { get; set; }

    /// <summary>
    /// Height of the page header in cm
    /// </summary>
    public double PageFooterHeight { get; set; }

    /// <summary>
    /// Margin between page header and type area in cm
    /// </summary>
    public double PageFooterMargin { get; set; }

    /// <summary>
    /// Dots per inch (for converting to pixels). Default: 96dpi
    /// </summary>
    public double DotsPerInch { get; set; }

    /// <summary>
    /// Coordinates of the vertical lines of the typo grid
    /// </summary>
    public double[] VerticalLines { get; private set; }

    /// <summary>
    /// Create all vertical lines for the typographic grid
    /// </summary>
    public void CalculateVerticalLines()
    {
        var numberOfLines = ColumnCount * 2;

        VerticalLines = new double[numberOfLines];

        for (var i = 0; i < ColumnCount; i++)
        {
            VerticalLines[i * 2] = MarginLeft + i * (ColumnWidth + ColumnDividerWidth);
            VerticalLines[i * 2 + 1] = MarginLeft + i * (ColumnWidth + ColumnDividerWidth) + ColumnWidth;
        }
    }

    /// <summary>
    /// Path to logo to print in the page header
    /// </summary>
    public string LogoPath { get; set; }

    /// <summary>
    /// Width of the logo in the page header in cm
    /// </summary>
    public double LogoWidth { get; set; }

    /// <summary>
    /// Styling for charts in the document
    /// </summary>
    public ChartStyle ChartStyle { get; set; }


    /// <summary>
    /// Color for table header background
    /// </summary>
    public TypoColor TableHeaderBackground { get; set; }


    /// <summary>
    /// Color for table body background
    /// </summary>
    public TypoColor TableBodyBackground { get; set; }


    /// <summary>
    /// Color for table header background
    /// </summary>
    public TypoColor TableHeaderUnborderedBackground { get; set; }


    /// <summary>
    /// Color for table body background
    /// </summary>
    public TypoColor TableBodyUnborderedBackground { get; set; }


    /// <summary>
    /// Corner radius of a table in cm
    /// </summary>
    public double TableCornerRadius { get; set; }

    #region Methods

    /// <summary>
    /// Set ratios used to calculate margins. Margins are calculate as follows:
    /// 
    /// <see cref="MarginUnit"/> = <see cref="PageWidth"/> - <see cref="TypeAreaWidth"/> / (<see cref="MarginLeftFactor"/> + <see cref="MarginRightFactor"/>)
    /// 
    /// <see cref="MarginLeft"/> = <see cref="MarginLeftFactor"/> * <see cref="MarginUnit"/>
    /// <see cref="MarginRight"/> = <see cref="MarginRightFactor"/> * <see cref="MarginUnit"/>
    /// <see cref="MarginTop"/> = <see cref="MarginTopFactor"/> * <see cref="MarginUnit"/>
    /// <see cref="MarginBottom"/> = <see cref="MarginBottomFactor"/>* <see cref="MarginUnit"/>
    /// 
    /// </summary>
    public void SetMargins()
    {
        TypeAreaWidth = ColumnCount * ColumnWidth + (ColumnCount - 1) * ColumnDividerWidth;


        var mu = PageWidth - TypeAreaWidth;

        MarginUnit = mu / (MarginLeftFactor + MarginRightFactor);

        MarginLeft = MarginLeftFactor * MarginUnit;
        MarginRight = MarginRightFactor * MarginUnit;
        MarginTop = MarginTopFactor * MarginUnit;
        MarginBottom = MarginBottomFactor * MarginUnit;

        TypeAreaHeight = PageHeight - MarginTop - MarginBottom;
    }

    /// <summary>
    /// Get the width of a landscape element which should a certain number of layout columns in cm
    /// </summary>
    /// <param name="numberOfColumnsUsed"></param>
    /// <returns></returns>
    public double GetWidth(int numberOfColumnsUsed)
    {
        return numberOfColumnsUsed * ColumnWidth + (numberOfColumnsUsed - 1) * ColumnDividerWidth;
    }

    /// <summary>
    /// Get the height of an element using the Golden Schnitt ratio in cm
    /// </summary>
    /// <param name="numberOfColumnsUsed"></param>
    /// <param name="landscape"></param>
    /// <returns></returns>
    public double GetHeight(int numberOfColumnsUsed, bool landscape = true)
    {
        return landscape
            ? Math.Round((numberOfColumnsUsed * ColumnWidth + (numberOfColumnsUsed - 1) * ColumnDividerWidth) /
                         TypographicConstants.GoldenerSchnittRatio, 2)
            : Math.Round((numberOfColumnsUsed * ColumnWidth + (numberOfColumnsUsed - 1) * ColumnDividerWidth) *
                         TypographicConstants.GoldenerSchnittRatio, 2);
    }


    /// <summary>
    /// Get the width of a landscape element which should a certain number of layout columns in pixels
    /// </summary>
    /// <param name="numberOfColumnsUsed"></param>
    /// <returns></returns>
    public int GetPixelWidth(int numberOfColumnsUsed)
    {
        return (int)(GetWidth(numberOfColumnsUsed) * TypographicConstants.InchPerCentimeter * DotsPerInch);
    }

    /// <summary>
    /// Get the height of an element using the Golden Schnitt ratio in pixels
    /// </summary>
    /// <param name="numberOfColumnsUsed"></param>
    /// <param name="landscape"></param>
    /// <returns></returns>
    public int GetPixelHeight(int numberOfColumnsUsed, bool landscape = true)
    {
        return (int)(GetHeight(numberOfColumnsUsed, landscape) * TypographicConstants.InchPerCentimeter * DotsPerInch);
    }


    #endregion


    #region Calculated values
    /// <summary>
    /// Width of the type area in cm (Breite des Satzspiegels in cm)
    /// </summary>
    public double TypeAreaWidth { get; private set; }

    /// <summary>
    /// Height of the type area in cm (Höhe des Satzspiegels in cm)
    /// </summary>
    public double TypeAreaHeight { get; set; }

    #endregion


}