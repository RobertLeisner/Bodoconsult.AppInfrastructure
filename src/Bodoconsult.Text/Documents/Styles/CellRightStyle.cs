// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="CellRightStyle"/> instances
/// </summary>
public class CellRightStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CellRightStyle()
    {
        TagToUse = "CellRightStyle";
        Name = TagToUse;
        TextAlignment = TypoTextAlignment.Right;
        //BorderBrush = new SolidColorBrush(Styleset.DefaultColor);
        //BorderThickness = new Thickness(1.0, 1.0, 1.0, 1.0);
        Paddings = new Thickness(Styleset.DefaultTablePaddingWidth);
        LineSpacingRule = LineSpacingRuleEnum.Auto;
    }
}