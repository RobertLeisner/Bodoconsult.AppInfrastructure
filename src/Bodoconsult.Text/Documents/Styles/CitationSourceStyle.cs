// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.


using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Citation"/> source instances
/// </summary>
public class CitationSourceStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationSourceStyle()
    {
        TagToUse = "CitationSourceStyle";
        Name = TagToUse;
        TextAlignment = TypoTextAlignment.Center;
        Margins.Top = 0;
        Margins.Bottom = MeasurementHelper.GetCmFromPt(0.5 *Styleset.DefaultFontSize);
        Margins.Left = Styleset.DefaultMarginLeft;
        Margins.Right = Styleset.DefaultMarginRight;
        FontSize = Styleset.DefaultFontSize - 4;
    }
}