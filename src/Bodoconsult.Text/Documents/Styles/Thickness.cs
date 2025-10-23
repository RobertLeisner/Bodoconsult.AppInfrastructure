// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System;
using Bodoconsult.App.Abstractions.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Thickness definition for margins and 
/// </summary>
public class Thickness : PropertyAsAttributeElement
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Thickness()
    { }

    /// <summary>
    /// Ctor with thickness values provided for left, top, right and bottom
    /// </summary>
    /// <param name="left">Left thickness in pt</param>
    /// <param name="top">Top thickness in pt</param>
    /// <param name="right">Right thickness in cm</param>
    /// <param name="bottom">Bottom thickness in pt</param>
    public Thickness(double left, double top, double right, double bottom)
    {
        Left = left;
        Right = right;
        Top = top;
        Bottom = bottom;
    }

    /// <summary>
    /// Ctor with a uniform value provided for left, top, right and bottom
    /// </summary>
    /// <param name="uniformValue"></param>
    public Thickness(double uniformValue)
    {
        Left = uniformValue;
        Right = uniformValue;
        Top = uniformValue;
        Bottom = uniformValue;
    }

    /// <summary>
    /// Ctor providing a LDML property string with 4 numbers separated by comma like 0,6,0,0
    /// </summary>
    /// <param name="values">LDML property string</param>
    public Thickness(string values)
    {
        var data = values.Split(',');

        Left = Convert.ToDouble(data[0]);
        Top = Convert.ToDouble(data[1]);
        Right = Convert.ToDouble(data[2]);
        Bottom = Convert.ToDouble(data[3]);
    }

    /// <summary>
    /// Left thickness in pt
    /// </summary>
    public double Left { get; set; }

    /// <summary>
    /// Top thickness in pt
    /// </summary>
    public double Top { get; set; } = Styleset.DefaultFontSize * 0.5;

    /// <summary>
    /// Right thickness in pt
    /// </summary>
    public double Right { get; set; }

    /// <summary>
    /// Bottom thickness in pt
    /// </summary>
    public double Bottom { get; set; }

    /// <summary>
    /// Get the element data as formatted property value for an LDML attribute
    /// </summary>
    public override string ToPropertyValue()
    {
        if (Left < TypeHelper.ToleranceValueComparisonsDouble && Top < TypeHelper.ToleranceValueComparisonsDouble &&
            Right < TypeHelper.ToleranceValueComparisonsDouble && Bottom < TypeHelper.ToleranceValueComparisonsDouble)
        {
            return null;
        }

        return $"{Left},{Top},{Right},{Bottom}";
    }
}