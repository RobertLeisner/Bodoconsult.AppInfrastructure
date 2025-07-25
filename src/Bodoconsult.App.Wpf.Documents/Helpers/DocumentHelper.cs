// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Services;
using Bodoconsult.App.Wpf.Helpers;
using System.Windows;

namespace Bodoconsult.App.Wpf.Documents.Helpers;

/// <summary>
/// Provides small helpers around the WPF flowdocuments
/// </summary>
public class DocumentHelper
{

    // ToDo: Replace some methods with the ones from Bodoconsult.App.Wpf.WpfHelper

    /// <summary>
    /// Elegant page margins
    /// </summary>
    public static Thickness PageMarginsElegant = new Thickness(114, 46, 95, 46);


    /// <summary>
    /// Elegant page margins
    /// </summary>
    public static Thickness PageMarginsRegular = new Thickness(95, 76, 76, 76);


    /// <summary>
    /// Elegant page margins
    /// </summary>
    public static Thickness PageMarginsSmall = new Thickness(76, 57, 57, 57);



    /// <summary>
    /// Get page margins from centimeters
    /// </summary>
    /// <param name="leftInCm">left margin in centimeters</param>
    /// <param name="topInCm">top margin in centimeters</param>
    /// <param name="rightInCm">right margin in centimeters</param>
    /// <param name="bottomInCm">bottom margin in centimeters</param>
    /// <returns></returns>
    public static Thickness PageMarginsFromCentimeters(double leftInCm, double topInCm, double rightInCm, double bottomInCm)
    {
        return new Thickness(WpfHelper.GetDiuFromCm(leftInCm),
            WpfHelper.GetDiuFromCm(topInCm),
            WpfHelper.GetDiuFromCm(rightInCm),
            WpfHelper.GetDiuFromCm(bottomInCm));
    }

    /// <summary>
    /// Set elegant A4 page settings 
    /// </summary>
    public static void A4ElegantPrintDefintion(TypographySettingsService typographySettingsService)
    {
        typographySettingsService.Margins = PageMarginsElegant;
        typographySettingsService.HeaderHeight = 56;
        typographySettingsService.HeaderMarginBottom = 25;
        typographySettingsService.FooterMarginTop = 14;
    }




}