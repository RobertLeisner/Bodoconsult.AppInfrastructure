// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="SectionSubtitle"/> instances
/// </summary>
public class SectionSubtitleStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitleStyle()
    {
        TagToUse = "SectionSubtitleStyle";
        Name = TagToUse;
        FontSize = Styleset.DefaultFontSize + 2;
        Margins.Top = MeasurementHelper.GetCmFromPt(Styleset.DefaultFontSize * 2);
        TextAlignment = TypoTextAlignment.Center;
        Bold = true;
    }
}