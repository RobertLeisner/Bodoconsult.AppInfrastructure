// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Describes a rectangle area on the paper
/// </summary>
[DebuggerDisplay("P1 ({Point1.X},{Point1.Y}), P2 ({Point2.X},{Point2.Y}), Size ({Size.Width} cm x {Size.Height} cm)")]
public struct TypoRect
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="point1">Left top point of the rectangle</param>
    /// <param name="point2">Left top point of the rectangle</param>

    public TypoRect(TypoPoint point1, TypoPoint point2)
    {
        Point1 = point1;
        Point2 = point2;
        Size = new TypoSize(Math.Abs(point2.X - point1.X), Math.Abs(point2.Y - point1.Y));
    }

    /// <summary>
    /// Left top point of the rectangle
    /// </summary>
    public TypoPoint Point1 { get;  }

    /// <summary>
    /// Left top point of the rectangle
    /// </summary>
    public TypoPoint Point2 { get;  }

    /// <summary>
    /// Size of the rectangle
    /// </summary>
    public TypoSize Size { get;  }
}