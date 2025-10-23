// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Table"/> instances
/// </summary>
public class TableHeaderLeftStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderLeftStyle()
    {
        TagToUse = "TableHeaderLeftStyle";
        Name = TagToUse;
        Bold = true;
        BorderBrush = new SolidColorBrush(Styleset.DefaultColor);
        BorderThickness = new Thickness(1.0, 1.0, 1.0, 1.0);
        Paddings = new Thickness(Styleset.DefaultTablePaddingWidth);
        TextAlignment = TextAlignment.Left;
    }
}