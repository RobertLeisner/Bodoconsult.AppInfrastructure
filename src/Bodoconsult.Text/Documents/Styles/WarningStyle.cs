// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.Text.Extensions;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Warning"/> instances
/// </summary>
public class WarningStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningStyle()
    {
        TagToUse = "WarningStyle";
        Name = TagToUse;
        BorderBrush = new SolidColorBrush(TypoColors.Yellow.ToLdmlColor());
        BorderThickness.Bottom = Styleset.DefaultBorderWidth;
        BorderThickness.Left = Styleset.DefaultBorderWidth;
        BorderThickness.Right = Styleset.DefaultBorderWidth;
        BorderThickness.Top = Styleset.DefaultBorderWidth;
        Paddings.Left = Styleset.DefaultPaddingWidth;
        Paddings.Right = Styleset.DefaultPaddingWidth;
        Paddings.Top = Styleset.DefaultPaddingWidth;
        Paddings.Bottom = Styleset.DefaultPaddingWidth;
        Margins.Top = 3 * Styleset.DefaultPaddingWidth;
        Margins.Bottom = 3 * Styleset.DefaultPaddingWidth;
        KeepTogether = true;
    }
}