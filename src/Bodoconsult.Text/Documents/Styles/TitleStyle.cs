// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Title"/> instances
/// </summary>
public class TitleStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TitleStyle()
    {
        TagToUse = "TitleStyle";
        Name = TagToUse;
        FontSize = Styleset.DefaultFontSize + 8;
        Margins.Top = MeasurementHelper.GetCmFromPt(Styleset.DefaultFontSize * 4);
        Margins.Bottom = MeasurementHelper.GetCmFromPt(Styleset.DefaultFontSize * 2);
        TextAlignment = TypoTextAlignment.Center;
        Bold = true;
    }
}