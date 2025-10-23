// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="CellLeftStyle"/> instances
/// </summary>
public class CellLeftStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CellLeftStyle()
    {
        TagToUse = "CellLeftStyle";
        Name = TagToUse;
        TextAlignment = TextAlignment.Left;
        BorderBrush = new SolidColorBrush(Styleset.DefaultColor);
        BorderThickness = new Thickness(1.0, 1.0, 1.0, 1.0);
        Paddings = new Thickness(Styleset.DefaultTablePaddingWidth);
    }
}