// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Helpers;
using Bodoconsult.App.Wpf.Services;
using Bodoconsult.Typography;
using PropertyChanged;
using System.Windows;
using System.Windows.Media;
using Bodoconsult.App.Wpf.Delegates;
using FontFamily = System.Windows.Media.FontFamily;

namespace Bodoconsult.App.Wpf.Documents.Services;

/// <summary>
/// Set the typography settings for <see cref="FlowDocumentService"/> used in Typography.xaml
/// </summary>
[AddINotifyPropertyChangedInterface]
public class TypographySettingsService
{
    private double _tableBorderWidth;
    private Thickness _tableBorderThickness;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TypographySettingsService()
    {
        LoadPageDefaults();

        RegularLineHeight = 14;
        PrimaryFontName = "Calibri";
        SecondaryFontName = "Calibri";
        ThirdFontName = "Calibri";
        RegularFontSize = 14;
        SmallFontSize = 12;
        ExtraSmallFontSize = 10;
        Heading1FontSize = 18;
        Heading2FontSize = 16;
        Heading3FontSize = 16;
        Heading4FontSize = 14;
        Heading5FontSize = 14;
        TitleFontSize = 30;
        Title2FontSize = 22;


        //System.Windows.Application.Current.Dispatcher.Invoke(() =>
        //{
        //    TableBodyBackground = new SolidColorBrush(Color.FromArgb(255, 208, 223, 255));
        //    TableHeaderBackground = new SolidColorBrush(Color.FromArgb(255, 178, 204, 255));
        //    TableBodyUnborderedBackground = new SolidColorBrush(Colors.Transparent);
        //    TableHeaderUnborderedBackground = new SolidColorBrush(Colors.Transparent);
        //    TableCornerRadius = 5;
        //});

        //SetDefaultMargins();

    }

    /// <summary>
    /// Ctor to load settings from a typography
    /// </summary>
    /// <param name="typography">Current typography instance to load</param>
    public TypographySettingsService(ITypography typography)
    {

        PageSize = new Size(WpfHelper.GetDiuFromCm(typography.PageWidth),
            WpfHelper.GetDiuFromCm(typography.PageHeight));

        Margins = new Thickness(WpfHelper.GetDiuFromCm(typography.MarginLeft),
            WpfHelper.GetDiuFromCm(typography.MarginTop - typography.PageHeaderHeight -
                                   typography.PageHeaderMargin),
            WpfHelper.GetDiuFromCm(typography.MarginRight),
            WpfHelper.GetDiuFromCm(typography.MarginBottom - typography.PageFooterHeight -
                                   typography.PageFooterMargin));

        HeaderHeight = WpfHelper.GetDiuFromCm(typography.PageHeaderHeight);
        HeaderMarginBottom = WpfHelper.GetDiuFromCm(typography.PageHeaderMargin);
        FooterMarginTop = WpfHelper.GetDiuFromCm(typography.PageFooterMargin);
        FooterHeight = WpfHelper.GetDiuFromCm(typography.PageFooterHeight);
        FooterFontName = typography.FontName;
        FooterFontSize = WpfHelper.PointToDiu(typography.SmallFontSize);
        LogoPath = typography.LogoPath;
        LogoWidth = WpfHelper.GetDiuFromCm(typography.LogoWidth);

        HeaderHeight += HeaderMarginBottom;
        FooterHeight += FooterMarginTop;

        RegularLineHeight = typography.LineHeight;
        PrimaryFontName = typography.FontName;
        SecondaryFontName = typography.HeadingFontName;
        ThirdFontName = typography.TitleFontName;
        RegularFontSize = typography.FontSize;
        SmallFontSize = typography.SmallFontSize;
        TitleFontSize = typography.TitleFontSize;
        Title2FontSize = typography.SubTitleFontSize;
        Heading1FontSize = typography.HeadingFontSize1;
        Heading2FontSize = typography.HeadingFontSize2;
        Heading3FontSize = typography.HeadingFontSize3;
        Heading4FontSize = typography.HeadingFontSize4;
        Heading5FontSize = typography.HeadingFontSize5;
        ExtraSmallFontSize = typography.ExtraSmallFontSize;
    }

    #region Page settings

    /// <summary>
    /// Page size in DIUs
    /// </summary>
    public Size PageSize { get; set; }

    /// <summary>
    /// Page margins
    /// </summary>
    public Thickness Margins { get; set; }

    /// <summary>
    /// Space reserved for the header in DIUs
    /// </summary>
    public double HeaderHeight { get; set; }

    /// <summary>
    /// Bottom margin of the header in DIUs
    /// </summary>
    public double HeaderMarginBottom { get; set; }

    /// <summary>
    /// Space reserved for the footer in DIUs
    /// </summary>
    public double FooterHeight { get; set; }

    /// <summary>
    /// Margin in footer above the footer text and below the main text
    /// </summary>
    public double FooterMarginTop { get; set; }

    #endregion


    #region Formatting properties

    /// <summary>
    /// Text to be printed in the page header
    /// </summary>
    public string HeaderText { get; set; }

    /// <summary>
    /// Font name to use for header
    /// </summary>
    public string HeaderFontName { get; set; }

    /// <summary>
    /// Header font size
    /// </summary>
    public double HeaderFontSize { get; set; }

    /// <summary>
    /// Text to be printed in the page footer
    /// </summary>
    public string FooterText { get; set; }

    /// <summary>
    /// Font name to use for footer
    /// </summary>
    public string FooterFontName { get; set; }

    /// <summary>
    /// Footer font size
    /// </summary>
    public double FooterFontSize { get; set; }

    /// <summary>
    /// Text like page or Seite to write in front of the page number in the footer
    /// </summary>
    public string FooterPageText { get; set; } = "Page";

    /// <summary>
    /// Absolute or relative path to the logo to print in the page header
    /// </summary>
    public string LogoPath { get; set; }

    /// <summary>
    /// Width of the logo to print in the page header
    /// </summary>
    public double LogoWidth { get; set; }

    /// <summary>
    /// Maximum height for images in the document
    /// </summary>
    public double MaxImageHeight { get; set; }

    /// <summary>
    /// Maximum width for images in the document
    /// </summary>
    public double MaxImageWidth { get; set; }

    /// <summary>
    /// Language code like en or de (only first 2 letters needed). Default: de
    /// </summary>
    public string CurrentLanguage { get; set; } = "de";

    ///// <summary>
    ///// The name used to register the current used language resources. See <see cref="LanguageResourceService"/>.
    ///// Needs a <see cref="CurrentLanguage"/> to be defined too to work properly
    ///// </summary>
    //public string CurrentLanguageModule { get; set; }

    /// <summary>
    /// Prefix used for the ongoing numbering of figures in the report
    /// </summary>
    public string FigureCounterPrefix { get; set; }

    /// <summary>
    /// Name of the default style
    /// </summary>
    public string DefaultStyleName { get; set; }

    /// <summary>
    /// Set an individual XAML resource file for formatting the document.
    /// Resource file must follow the rules of Typography.XAML in Bodoconsult.Wpf.Documents
    /// </summary>
    public string UserDefinedTypographyFile { get; set; }

    /// <summary>
    /// Show an ongoing numbering in the legend of each figure
    /// </summary>
    public bool ShowFigureCounter { get; set; }

    /// <summary>
    /// Automatically count the headlines per level and add numbers to headline printed
    /// </summary>
    public bool AutoNumbering { get; set; }

    /// <summary>
    /// Template used to resolve images in textblocks
    /// </summary>
    public string ImageTemplate { get; set; } = "<Figure CanDelayPlacement=\"false\" HorizontalAnchor=\"ColumnCenter\"><BlockUIContainer><Image Source=\"{0}\" MaxHeight=\"{2}\" MaxWidth=\"{3}\"/></BlockUIContainer>{1}</Figure>";

    ///<summary>
    /// Repeat table headers? Default: false
    ///</summary>
    public bool RepeatTableHeaders { get; set; }

    #endregion

    #region Delegates for drawing main page sections

    /// <summary>
    /// Delegate to print a header to the document page
    /// </summary>
    public DrawSectionDelegate DrawHeaderDelegate;

    /// <summary>
    /// Delegate to print a footer to the document page
    /// </summary>
    public DrawSectionDelegate DrawFooterDelegate;

    #endregion


    #region Important measures for page sections calculate from page settings

    /// <summary>
    /// Current content size
    /// </summary>
    public Size ContentSize
    {
        get
        {
            var size = new Size(PageSize.Width - Margins.Left - Margins.Right,
                PageSize.Height - (Margins.Top + Margins.Bottom + HeaderHeight + FooterHeight));

            return size;
        }
    }

    /// <summary>
    /// The origin of the content
    /// </summary>
    public Point ContentOrigin =>
        new(
            Margins.Left,
            Margins.Top + HeaderRect.Height
        );

    /// <summary>
    /// The defined header area
    /// </summary>
    public Rect HeaderRect =>
        new(
            Margins.Left, Margins.Top,
            ContentSize.Width, HeaderHeight
        );

    /// <summary>
    /// The defined footer area
    /// </summary>
    public Rect FooterRect =>
        new(
            Margins.Left, ContentOrigin.Y + ContentSize.Height,
            ContentSize.Width, FooterHeight
        );

    #endregion


    #region Text formatting settings





    /// <summary>
    /// Name of primary font
    /// </summary>
    public string PrimaryFontName { get; set; }

    /// <summary>
    /// Font family of the primary font. <see cref="PrimaryFontName"/> must be set
    /// </summary>
    public FontFamily PrimaryFontFamily
    {
        get
        {
            FontFamily f = null;

            Application.Current.Dispatcher.Invoke(() => f = new FontFamily(PrimaryFontName));

            return f;
        }
    }


    /// <summary>
    /// Name of primary font
    /// </summary>
    public string SecondaryFontName { get; set; }

    /// <summary>
    /// Font family of the primary font. <see cref="SecondaryFontName"/> must be set
    /// </summary>
    public FontFamily SecondaryFontFamily
    {
        get
        {
            FontFamily f = null;
            Application.Current.Dispatcher.Invoke(() => f = new FontFamily(SecondaryFontName));
            return f;
        }
    }



    /// <summary>
    /// Name of third font
    /// </summary>
    public string ThirdFontName { get; set; }

    /// <summary>
    /// Font family of the third font. <see cref="ThirdFontName"/> must be set
    /// </summary>
    public FontFamily ThirdFontFamily
    {
        get
        {
            FontFamily f = null;
            Application.Current.Dispatcher.Invoke(() => f = new FontFamily(ThirdFontName));
            return f;
        }
    }




    /// <summary>
    /// Regular font size
    /// </summary>
    public double RegularFontSize { get; set; }

    /// <summary>
    /// Line height of regular text
    /// </summary>
    public double RegularLineHeight { get; set; }


    /// <summary>
    /// Font size for small text
    /// </summary>
    public double SmallFontSize { get; set; }


    /// <summary>
    /// Font size for tiny text
    /// </summary>
    public double ExtraSmallFontSize { get; set; }


    /// <summary>
    /// Font size for heading level 1
    /// </summary>
    public double Heading1FontSize { get; set; }

    /// <summary>
    /// Font size for heading level 2
    /// </summary>
    public double Heading2FontSize { get; set; }

    /// <summary>
    /// Font size for heading level 3
    /// </summary>
    public double Heading3FontSize { get; set; }

    /// <summary>
    /// Font size for heading level 4
    /// </summary>
    public double Heading4FontSize { get; set; }

    /// <summary>
    /// Font size for heading level 5
    /// </summary>
    public double Heading5FontSize { get; set; }

    /// <summary>
    /// Font size for title level 1
    /// </summary>
    public double TitleFontSize { get; set; }

    /// <summary>
    /// Font size for title level 2
    /// </summary>
    public double Title2FontSize { get; set; }



    /// <summary>
    /// Regular margins for text
    /// </summary>
    public Thickness RegularThickness { get; set; }


    /// <summary>
    /// Regular margins for table content
    /// </summary>
    public Thickness TableContentThickness { get; set; }

    /// <summary>
    /// Small margins for table content
    /// </summary>
    public Thickness TableContentSmallThickness { get; set; }

    /// <summary>
    /// Tiny margins for table content
    /// </summary>
    public Thickness TableContentExtraSmallThickness { get; set; }

    /// <summary>
    /// Regular margins for table content
    /// </summary>
    public Thickness TableContentUnborderedThickness { get; set; }

    /// <summary>
    /// Small margins for table content
    /// </summary>
    public Thickness TableContentSmallUnborderedThickness { get; set; }

    /// <summary>
    /// Tiny margins for table content
    /// </summary>
    public Thickness TableContentExtraSmallUnborderedThickness { get; set; }


    /// <summary>
    /// Margins for heading level 5
    /// </summary>
    public Thickness Heading5Thickness { get; set; }
    /// <summary>
    /// Margins for heading level 4
    /// </summary>
    public Thickness Heading4Thickness { get; set; }
    /// <summary>
    /// Margins for heading level 3
    /// </summary>
    public Thickness Heading3Thickness { get; set; }
    /// <summary>
    /// Margins for heading level 2
    /// </summary>
    public Thickness Heading2Thickness { get; set; }
    /// <summary>
    /// Margins for heading level 1
    /// </summary>
    public Thickness Heading1Thickness { get; set; }

    /// <summary>
    /// Margins for title level 1
    /// </summary>
    public Thickness TitleThickness { get; set; }


    /// <summary>
    /// Margins for title level 2
    /// </summary>
    public Thickness Title2Thickness { get; set; }

    /// <summary>
    /// Margin around figures
    /// </summary>
    public Thickness FigureThickness { get; set; }

    /// <summary>
    /// Color for table header background
    /// </summary>
    public Brush TableHeaderBackground { get; set; }


    /// <summary>
    /// Color for table body background
    /// </summary>
    public Brush TableBodyBackground { get; set; }

    /// <summary>
    /// Color for table body border
    /// </summary>
    public Brush TableBorder { get; set; }

    /// <summary>
    /// Color for table header background
    /// </summary>
    public Brush TableHeaderUnborderedBackground { get; set; }

    /// <summary>
    /// Color for table body background
    /// </summary>
    public Brush TableBodyUnborderedBackground { get; set; }


    /// <summary>
    /// Corner radius of a table
    /// </summary>
    public double TableCornerRadius { get; set; }

    /// <summary>
    /// Margins around a table
    /// </summary>
    public Thickness TableThickness { get; set; }

    /// <summary>
    /// Border around a table
    /// </summary>
    public Thickness TableBorderThickness => _tableBorderThickness;

    /// <summary>
    /// Border width of tables
    /// </summary>
    public double TableBorderWidth
    {
        get => _tableBorderWidth;
        set
        {
            _tableBorderWidth = value;
            _tableBorderThickness = new(_tableBorderWidth, 0, _tableBorderWidth, 0);
        }
    }

    /// <summary>
    /// Set default margins based on regular font size
    /// </summary>
    public void SetDefaultMargins()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            var quarterSize = Math.Ceiling(RegularFontSize / 4.0);

            RegularThickness = new Thickness(0, quarterSize, 0, 0);
            TableContentThickness = new Thickness(quarterSize, 0, quarterSize, 0);
            TableContentSmallThickness = new Thickness(quarterSize, 0, quarterSize, 0);
            TableContentExtraSmallThickness = new Thickness(quarterSize - 1, 0, quarterSize - 1, 0);
            TableThickness = new Thickness(0, 4 * quarterSize, 0, 2 * quarterSize);

            TableContentUnborderedThickness = new Thickness(0, 0, quarterSize, 0);
            TableContentSmallUnborderedThickness = new Thickness(0, 0, quarterSize, 0);
            TableContentExtraSmallUnborderedThickness = new Thickness(0, 0, quarterSize - 1, 0);

            Heading1Thickness = new Thickness(0, 4 * quarterSize, 0, 2 * quarterSize);
            Heading2Thickness = new Thickness(0, 4 * quarterSize, 0, 2 * quarterSize);
            Heading3Thickness = new Thickness(0, 4 * quarterSize, 0, 2 * quarterSize);
            Heading4Thickness = new Thickness(0, quarterSize, 0, 0);
            Heading5Thickness = new Thickness(0, quarterSize, 0, 0);
            TitleThickness = new Thickness(0, 48 * quarterSize, 0, 16 * quarterSize);
            Title2Thickness = new Thickness(0, 16 * quarterSize, 0, 8 * quarterSize);
            RegularLineHeight = RegularFontSize * 1.2;
            Heading1LineSeparatorThickness = new Thickness(0, 0, 0, 2 * quarterSize);
            FigureThickness = new Thickness(0, 2 * quarterSize, 0, 2 * quarterSize);
        });
    }

    /// <summary>
    /// Margin between heading1 tetxt and line below heading 1. Default 0.5*RegularFontSize
    /// </summary>
    public Thickness Heading1LineSeparatorThickness { get; set; }


    #endregion

    #region Private methods

    private void LoadPageDefaults()
    {
        RepeatTableHeaders = true;
        Margins = new Thickness(92.7, 55, 55, 55);
        PageSize = new Size(793.5987, 1122.3987);
        MaxImageHeight = 300;
        HeaderHeight = 45;
        FooterHeight = 25;
        HeaderMarginBottom = 20;
        DefaultStyleName = "Standard";
        FigureCounterPrefix = "Figure";
        AutoNumbering = true;
        ShowFigureCounter = true;

        ImageTemplate = "<Figure CanDelayPlacement=\"false\" HorizontalAnchor=\"ColumnCenter\"><BlockUIContainer><Image Source=\"{0}\" MaxHeight=\"{2}\" MaxWidth=\"{3}\"/></BlockUIContainer>{1}</Figure>";
        CurrentLanguage = "de";

        HeaderFontName = "Calibri";
        HeaderFontSize = 10.0;
        FooterFontName = "Calibri";
        FooterFontSize = 10.0;
        LogoWidth = 113;
    }

    #endregion

    #region Public methods




    /// <summary>
    /// Load default typography
    /// </summary>
    public void LoadDefaults()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {

            LoadPageDefaults();

            PrimaryFontName = "Calibri";
            SecondaryFontName = "Calibri";
            ThirdFontName = "Calibri";
            RegularFontSize = 14;
            SmallFontSize = 12;
            ExtraSmallFontSize = 10;
            Heading1FontSize = 18;
            Heading2FontSize = 16;
            Heading3FontSize = 16;
            Heading4FontSize = 14;
            Heading5FontSize = 14;
            TitleFontSize = 30;
            Title2FontSize = 22;

            TableBodyBackground = new SolidColorBrush(Colors.White);
            TableHeaderBackground = new SolidColorBrush(Colors.White);
            TableBodyUnborderedBackground = new SolidColorBrush(Colors.Transparent);
            TableHeaderUnborderedBackground = new SolidColorBrush(Colors.Transparent);
            TableBorder = TableHeaderBackground;
            TableCornerRadius = 5;
            TableBorderWidth = 2;
        });

        SetDefaultMargins();
    }

    /// <summary>
    /// Load default typography for a compact styling
    /// </summary>
    public void LoadCompactDefaults()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {

            LoadPageDefaults();

            PrimaryFontName = "Calibri";
            SecondaryFontName = "Calibri";
            ThirdFontName = "Calibri";
            RegularFontSize = 12;
            SmallFontSize = 10;
            ExtraSmallFontSize = 8;
            Heading1FontSize = 18;
            Heading2FontSize = 16;
            Heading3FontSize = 14;
            Heading4FontSize = 12;
            Heading5FontSize = 12;
            TitleFontSize = 24;
            Title2FontSize = 18;


            TableBodyBackground = new SolidColorBrush(Colors.White);
            TableHeaderBackground = new SolidColorBrush(Colors.White);
            TableBodyUnborderedBackground = new SolidColorBrush(Colors.Transparent);
            TableHeaderUnborderedBackground = new SolidColorBrush(Colors.Transparent);
            TableBorder = TableHeaderBackground;
            TableCornerRadius = 5;
            TableBorderWidth = 2;
        });

        SetDefaultMargins();
    }


    /// <summary>
    /// Load settings from <see cref="ITypography"/> Data
    /// </summary>
    /// <param name="typography"></param>
    public void LoadTypography(ITypography typography)
    {

        Application.Current.Dispatcher.Invoke(() =>
        {


            PrimaryFontName = typography.FontName;
            SecondaryFontName = typography.HeadingFontName;
            ThirdFontName = typography.TitleFontName;
            RegularFontSize = WpfHelper.PointToDiu(typography.FontSize);
            SmallFontSize = WpfHelper.PointToDiu(typography.SmallFontSize);
            ExtraSmallFontSize = WpfHelper.PointToDiu(typography.ExtraSmallFontSize);
            Heading1FontSize = WpfHelper.PointToDiu(typography.HeadingFontSize1);
            Heading2FontSize = WpfHelper.PointToDiu(typography.HeadingFontSize2);
            Heading3FontSize = WpfHelper.PointToDiu(typography.HeadingFontSize3);
            Heading4FontSize = WpfHelper.PointToDiu(typography.HeadingFontSize4);
            Heading5FontSize = WpfHelper.PointToDiu(typography.HeadingFontSize5);
            TitleFontSize = WpfHelper.PointToDiu(typography.TitleFontSize);
            Title2FontSize = WpfHelper.PointToDiu(typography.SubTitleFontSize);

            TableBodyBackground = new SolidColorBrush(WpfHelper.GetColor(typography.TableBodyBackground));
            TableHeaderBackground = new SolidColorBrush(WpfHelper.GetColor(typography.TableHeaderBackground));
            TableBodyUnborderedBackground = new SolidColorBrush(WpfHelper.GetColor(typography.TableBodyUnborderedBackground));
            TableHeaderUnborderedBackground = new SolidColorBrush(WpfHelper.GetColor(typography.TableHeaderUnborderedBackground));

            TableBorder = new SolidColorBrush(WpfHelper.GetColor(typography.TableBorderColor));
            TableCornerRadius = WpfHelper.GetDiuFromCm(typography.TableCornerRadius);
            TableBorderWidth = WpfHelper.GetDiuFromCm(typography.TableBorderWidth);

        });

        SetDefaultMargins();
    }

    #endregion
}