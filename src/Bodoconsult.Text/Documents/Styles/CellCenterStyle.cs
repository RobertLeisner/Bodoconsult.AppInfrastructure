// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="CellCenterStyle"/> instances
/// </summary>
public class CellCenterStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CellCenterStyle()
    {
        TagToUse = "CellCenterStyle";
        Name = TagToUse;
        TextAlignment = TypoTextAlignment.Center;
        BorderBrush = new SolidColorBrush(Styleset.DefaultColor);
        BorderThickness = new Thickness(1.0, 1.0, 1.0, 1.0);
        Paddings = new Thickness(Styleset.DefaultTablePaddingWidth);
    }
}