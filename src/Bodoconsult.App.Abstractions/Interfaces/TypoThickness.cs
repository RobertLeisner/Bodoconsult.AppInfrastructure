// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Thickness definition for margins and 
/// </summary>
public class TypoThickness
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TypoThickness()
    { }

    /// <summary>
    /// Ctor with thickness values provided for left, top, right and bottom
    /// </summary>
    /// <param name="left">Left thickness in pt</param>
    /// <param name="top">Top thickness in pt</param>
    /// <param name="right">Right thickness in cm</param>
    /// <param name="bottom">Bottom thickness in pt</param>
    public TypoThickness(double left, double top, double right, double bottom)
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
    public TypoThickness(double uniformValue)
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
    public TypoThickness(string values)
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
    public double Top { get; set; } 

    /// <summary>
    /// Right thickness in pt
    /// </summary>
    public double Right { get; set; }

    /// <summary>
    /// Bottom thickness in pt
    /// </summary>
    public double Bottom { get; set; }
}