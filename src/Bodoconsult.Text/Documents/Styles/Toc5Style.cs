// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Toc5"/> instances
/// </summary>
public class Toc5Style : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc5Style()
    {
        TagToUse = "Toc5Style";
        Name = TagToUse;
        Margins.Left = MeasurementHelper.GetCmFromPt(4 * Styleset.DefaultFontSize);
        FontSize = Styleset.DefaultFontSize;
    }
}