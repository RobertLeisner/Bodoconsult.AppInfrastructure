// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Delegates;
using Bodoconsult.App.Wpf.Documents.Interfaces;
using Bodoconsult.Text.Documents;
using PropertyChanged;
using System.Globalization;
using System.Windows;
using Bodoconsult.App.Wpf.Documents.Delegates;

namespace Bodoconsult.App.Wpf.Documents.Services;

/// <summary>
/// Base class used for WPF page settings
/// </summary>
[AddINotifyPropertyChangedInterface]
public abstract class BasePageSettingsService : IPageSettingsService
{
    private string _currentLanguage = "de";

    #region Page settings

    /// <summary>
    /// Language code like en or de (only first 2 letters needed). Default: de
    /// </summary>
    public string CurrentLanguage
    {
        get => _currentLanguage;
        set
        {
            _currentLanguage = value;
            CultureInfo = new CultureInfo(value);
        }
    }

    /// <summary>
    /// Current culture info
    /// </summary>
    public CultureInfo CultureInfo { get; private set; } = new("de");

    /// <summary>
    /// Page size in DIUs
    /// </summary>
    public Size PageSize { get; set; }

    /// <summary>
    /// Page margins in DIUs
    /// </summary>
    public System.Windows.Thickness Margins { get; set; }

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
    public double FooterHeight { get; set; } = 25;

    /// <summary>
    /// Margin in footer above the footer text and below the main text in DIUs
    /// </summary>
    public double FooterMarginTop { get; set; } = 14;

    #endregion

    #region Delegates for drawing main page sections

    /// <summary>
    /// Delegate to print a header to the document page
    /// </summary>
    public DrawSectionDelegate DrawHeaderDelegate { get; set; }

    /// <summary>
    /// Delegate to print a footer to the document page
    /// </summary>
    public DrawSectionDelegate DrawFooterDelegate { get; set; }

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


    ///<summary>
    /// Repeat table headers? Default: false
    ///</summary>
    public bool RepeatTableHeaders { get; set; }

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
    /// Width of the logo to print in the page header in DIUs
    /// </summary>
    public double LogoWidth { get; set; }

    /// <summary>
    /// Page number format for TOC, TOE, TOF and TOT sections
    /// </summary>
    public PageNumberFormatEnum TocPageNumberFormat { get; set; } = PageNumberFormatEnum.UpperRoman;

    /// <summary>
    /// Page number format for content sections
    /// </summary>
    public PageNumberFormatEnum ContentPageNumberFormat { get; set; } = PageNumberFormatEnum.Decimal;

}