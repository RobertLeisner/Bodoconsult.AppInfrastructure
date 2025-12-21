// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for TOE heading instances
/// </summary>
public class ToeHeadingStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeHeadingStyle()
    {
        TagToUse = "ToeHeadingStyle";
        Name = TagToUse;
        BorderBrush = new SolidColorBrush(Styleset.DefaultColor);
        BorderThickness.Bottom = 1 * Styleset.DefaultBorderWidth;
        BorderThickness.Top = 1 * Styleset.DefaultBorderWidth;
        Margins.Top = MeasurementHelper.GetCmFromPt(4 * Styleset.DefaultFontSize);
        Margins.Bottom = MeasurementHelper.GetCmFromPt(1 * Styleset.DefaultFontSize);
        Paddings.Top = Styleset.DefaultPaddingWidth;
        Paddings.Bottom = Styleset.DefaultPaddingWidth;
        Bold = true;
        FontSize = Styleset.DefaultFontSize + 2;
    }
}