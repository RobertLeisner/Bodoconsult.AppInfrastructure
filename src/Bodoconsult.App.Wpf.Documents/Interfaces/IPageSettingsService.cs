// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Globalization;
using System.Windows;
using Bodoconsult.App.Wpf.Documents.Delegates;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Interfaces;

/// <summary>
/// Interface for page settings used for paginator
/// </summary>
public interface IPageSettingsService
{
    /// <summary>
    /// Language code like en or de (only first 2 letters needed). Default: de
    /// </summary>
    public string CurrentLanguage { get; set; } 

    /// <summary>
    /// Current culture info
    /// </summary>
    public CultureInfo CultureInfo { get; }

    /// <summary>
    /// Page size in DIUs
    /// </summary>
    Size PageSize { get; set; }

    /// <summary>
    /// The origin of the content
    /// </summary>
    Point ContentOrigin { get; }

    /// <summary>
    /// Current content size
    /// </summary>
    Size ContentSize { get; }

    ///<summary>
    /// Repeat table headers? Default: false
    ///</summary>
    bool RepeatTableHeaders { get; set; }

    /// <summary>
    /// The defined header area
    /// </summary>
    Rect HeaderRect { get; }

    /// <summary>
    /// The defined footer area
    /// </summary>
    Rect FooterRect { get; }


    #region Delegates for drawing main page sections

    /// <summary>
    /// Delegate to print a header to the document page
    /// </summary>
    DrawSectionDelegate DrawHeaderDelegate { get; set; }

    /// <summary>
    /// Delegate to print a footer to the document page
    /// </summary>
    public DrawSectionDelegate DrawFooterDelegate { get; set; }

    /// <summary>
    /// Text to be printed in the page header
    /// </summary>
    string HeaderText { get; set; }

    /// <summary>
    /// Font name to use for header
    /// </summary>
    string HeaderFontName { get; set; }

    /// <summary>
    /// Header font size
    /// </summary>
    double HeaderFontSize { get; set; }

    /// <summary>
    /// Text to be printed in the page footer
    /// </summary>
    string FooterText { get; set; }

    /// <summary>
    /// Font name to use for footer
    /// </summary>
    string FooterFontName { get; set; }

    /// <summary>
    /// Footer font size
    /// </summary>
    double FooterFontSize { get; set; }

    /// <summary>
    /// Text like page or Seite to write in front of the page number in the footer
    /// </summary>
    string FooterPageText { get; set; }

    /// <summary>
    /// Absolute or relative path to the logo to print in the page header
    /// </summary>
    string LogoPath { get; set; }

    /// <summary>
    /// Width of the logo to print in the page header in DIUs
    /// </summary>
    double LogoWidth { get; set; }

    /// <summary>
    /// Page number format for TOC, TOE, TOF and TOT sections
    /// </summary>
    public PageNumberFormatEnum TocPageNumberFormat { get; set; }

    /// <summary>
    /// Page number format for content sections
    /// </summary>
    public PageNumberFormatEnum ContentPageNumberFormat { get; set; }

    #endregion
}