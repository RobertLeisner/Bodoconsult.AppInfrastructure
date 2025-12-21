// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="SectionTitle"/> instances
/// </summary>
public class SectionTitleStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleStyle()
    {
        TagToUse = "SectionTitleStyle";
        Name = TagToUse;
        TextAlignment = TypoTextAlignment.Center;
        Margins.Top = MeasurementHelper.GetCmFromPt(Styleset.DefaultFontSize * 4);
        FontSize = Styleset.DefaultFontSize + 4;
        Bold = true;
    }
}