// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Citation"/> instances
/// </summary>
public class CitationStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationStyle()
    {
        TagToUse = "CitationStyle";
        Name = TagToUse;
        TextAlignment = TypoTextAlignment.Center;
        Margins.Top = MeasurementHelper.GetCmFromPt(0.5 * Styleset.DefaultFontSize);
        Margins.Bottom = 0;
        Margins.Left = Styleset.DefaultMarginLeft;
        Margins.Right = Styleset.DefaultMarginRight;
        Italic = true;
        KeepWithNextParagraph = true;
        KeepTogether = true;
    }
}