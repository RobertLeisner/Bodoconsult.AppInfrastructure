// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Subtitle"/> instances
/// </summary>
public class SubtitleStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitleStyle()
    {
        TagToUse = "SubtitleStyle";
        Name = TagToUse;
        FontSize = Styleset.DefaultFontSize + 4;
        Margins.Top = MeasurementHelper.GetCmFromPt(Styleset.DefaultFontSize * 2);
        TextAlignment = TypoTextAlignment.Center;
        Bold = true;
    }
}