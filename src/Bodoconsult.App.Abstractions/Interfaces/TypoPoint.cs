// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// X and Y axis coordinates of a point on the paper
/// </summary>
[DebuggerDisplay("x = {X} y = {Y}")]
public struct TypoPoint
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="x">X coordinate in cm</param>
    /// <param name="y">Y coordinate in cm</param>
    public TypoPoint(double x, double y)
    {
        X = x; 
        Y = y;
    }

    /// <summary>
    /// X coordinate in cm
    /// </summary>
    public double X { get; }

    /// <summary>
    /// Y coordinate in cm
    /// </summary>
    public double Y { get; }
}