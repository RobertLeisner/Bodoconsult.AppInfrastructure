// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Table"/> legend instances
/// </summary>
public class TableLegendStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TableLegendStyle()
    {
        TagToUse = "TableLegendStyle";
        Name = TagToUse;
        Margins = new Thickness(0, MeasurementHelper.GetCmFromPt(Styleset.DefaultFontSize * 0.25), 0, MeasurementHelper.GetCmFromPt(Styleset.DefaultFontSize));
        TextAlignment = TypoTextAlignment.Center;
        Italic = true;
    }
}