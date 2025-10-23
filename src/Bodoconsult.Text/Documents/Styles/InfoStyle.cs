// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Info"/> instances
/// </summary>
public class InfoStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public InfoStyle()
    {
        TagToUse = "InfoStyle";
        Name = TagToUse;
        BorderBrush = new SolidColorBrush(Styleset.DefaultColor);
        BorderThickness.Bottom = Styleset.DefaultBorderWidth;
        BorderThickness.Left =   Styleset.DefaultBorderWidth;
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